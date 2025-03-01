﻿using DotSpatial.Controls;
using DotSpatial.Data;
using DotSpatial.Symbology;
using DotSpatial.Projections;
using DotSpatial.Data.Forms;
using System.Drawing;
using NetTopologySuite.Geometries;
using System;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using Microsoft.VisualBasic;
using OSGeo.GDAL;
using System.Text;
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private bool isAddingPoints = false;   // 是否处于添加点模式
        private bool isAddinglines = false;   // 是否处于添加线模式
        private Map map;
        private SaveFileDialog saveFileDialog = new SaveFileDialog();
        private IMapLayer? _selectedLayer;
        private IMapFeatureLayer? editingLayer;
        private PictureBox pictureBox1;
        private static bool _gdalInitialized = false;

       
        public Form1()
        {
            pictureBox1 = new PictureBox();
            InitializeComponent();
            map = new Map
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(map);
            map.MouseClick += Map_MouseClick;

            // 设置地图的投影
            map.Projection = KnownCoordinateSystems.Projected.World.WebMercator;
            this.DoubleBuffered = true;
        }
        private void InitializeGdalEnvironment()
        {
          if (!_gdalInitialized)
             {
                        // 注册所有驱动
             Gdal.AllRegister();

                        // 配置中文路径支持
             Gdal.SetConfigOption("GDAL_FILENAME_IS_UTF8", "YES");

                        // 标记已初始化
              _gdalInitialized = true;
          }
         }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void 放大ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            map.FunctionMode = FunctionMode.ZoomIn;
        }

        private void 缩小ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            map.FunctionMode = FunctionMode.ZoomOut;
        }

        private void 全景ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            map.ZoomToMaxExtent();
        }
        private void 选择ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            map.FunctionMode = FunctionMode.Select;
        }



        private void shpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Shapefile (*.shp)|*.shp"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                IFeatureSet featureSet = FeatureSet.OpenFile(dialog.FileName);
                IMapFeatureLayer layer = map.Layers.Add(featureSet);

                // 设置符号样式（示例：红色边框多边形）
                if (featureSet.FeatureType == FeatureType.Polygon)
                {
                    PolygonScheme scheme = new PolygonScheme();
                    scheme.Categories.Add(new PolygonCategory(Color.Transparent, Color.Red, 1));
                    layer.Symbology = scheme;
                }
                UpdateLayerList();
                map.ResetBuffer();
            }
        }

        private void tiffToolStripMenuItem_Click(object sender, EventArgs e)//tif文件
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "GeoTIFF Files (*.tif;*.tiff)|*.tif;*.tiff|All Files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Dataset dataset = null;
                    try
                    {
                        // 初始化GDAL环境
                        InitializeGdalEnvironment();

                        string filePath = openFileDialog.FileName;
                        dataset = Gdal.Open(filePath, Access.GA_ReadOnly);

                        if (dataset == null)
                        {
                            string errorMsg = Gdal.GetLastErrorMsg();
                            MessageBox.Show($"文件打开失败：{errorMsg}", "错误",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // 显示栅格元数据
                        ShowRasterInfo(dataset);
                    }
                    catch (Exception ex)
                    {
                        HandleGdalError(ex);
                    }
                    finally
                    {
                        // 释放资源
                        dataset?.Dispose();
                        GC.Collect(); // GDAL依赖GC清理非托管资源
                    }
                }
            }
        }
        private void ShowRasterInfo(Dataset dataset)
        {
            var info = new StringBuilder();
            info.AppendLine("▸ 文件基本信息");
            info.AppendLine($"波段数：{dataset.RasterCount}");
            info.AppendLine($"影像尺寸：{dataset.RasterXSize} x {dataset.RasterYSize}");

            // 获取地理变换参数
            double[] transform = new double[6];
            dataset.GetGeoTransform(transform);
            info.AppendLine($"\n▸ 地理参考");
            info.AppendLine($"左上角X：{transform[0]}");
            info.AppendLine($"水平分辨率：{transform[1]}");
            info.AppendLine($"旋转参数：{transform[2]}");
            info.AppendLine($"左上角Y：{transform[3]}");
            info.AppendLine($"垂直分辨率：{transform[5]}");

            // 显示信息
            MessageBox.Show(info.ToString(), "栅格信息",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void HandleGdalError(Exception ex)
        {
            var errorMsg = new StringBuilder();
            errorMsg.AppendLine("错误类型：" + ex.GetType().Name);
            errorMsg.AppendLine("详细信息：" + ex.Message);

            // 捕获GDAL特定错误
            if (ex is DllNotFoundException)
            {
                errorMsg.AppendLine("\n可能原因：");
                errorMsg.AppendLine("1. GDAL运行时库未正确安装");
                errorMsg.AppendLine("2. 缺少 gdal_wrap.dll 或 gdal_csharp.dll");
            }

            MessageBox.Show(errorMsg.ToString(), "系统错误",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
        }



        private void 平移ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            map.FunctionMode = FunctionMode.Pan;
        }
        private void StartEditing(IMapFeatureLayer layer)
        {
            editingLayer = layer;

            map.FunctionMode = FunctionMode.Select; // 切换到选择模式
        }
        private void Map_MouseClick(object sender, MouseEventArgs e)//添加点
        {
            if (!isAddingPoints || editingLayer == null) return;

            if (e.Button == MouseButtons.Left)
            {
                // 将点击位置转换为地图坐标
                Coordinate coord = map.PixelToProj(e.Location);

                // 使用 NetTopologySuite.Geometries.Point
                NetTopologySuite.Geometries.Point point = new NetTopologySuite.Geometries.Point(coord.X, coord.Y);

                // 将点添加到图层
                IFeature feature = editingLayer.DataSet.AddFeature(point);

                // 设置点的显示样式（红色圆形，大小8像素）
                if (editingLayer.Symbology == null)
                {
                    // 使用 DotSpatial.Symbology.PointShape
                    var symbolizer = new PointSymbolizer(Color.Red, DotSpatial.Symbology.PointShape.Ellipse, 8);
                    editingLayer.Symbology = new PointScheme { Categories = { new PointCategory(symbolizer) } };
                }

                map.ResetBuffer(); // 刷新地图
            }
            else if (e.Button == MouseButtons.Right)
            {
                isAddingPoints = false;
                map.Cursor = Cursors.Default;
            }
        }
        private void Map_MouseChick_1(object sender, MouseEventArgs e)//添加线
        {
            if (!isAddinglines || editingLayer == null) return;
            if (e.Button == MouseButtons.Left)
            {
                // 将点击位置转换为地图坐标
                Coordinate coord = map.PixelToProj(e.Location);
                // 使用 NetTopologySuite.Geometries.Point
                NetTopologySuite.Geometries.Point point = new NetTopologySuite.Geometries.Point(coord.X, coord.Y);
                
                // 将点添加到图层
                IFeature feature = editingLayer.DataSet.AddFeature(point);
                // 设置点的显示样式（红色圆形，大小8像素）
                if (editingLayer.Symbology == null)
                {
                    // 使用 DotSpatial.Symbology.PointShape
                    var symbolizer = new PointSymbolizer(Color.Red, DotSpatial.Symbology.PointShape.Ellipse, 8);
                    editingLayer.Symbology = new PointScheme { Categories = { new PointCategory(symbolizer) } };
                }
                map.ResetBuffer(); // 刷新地图
            }
            else if (e.Button == MouseButtons.Right)
            {
                isAddinglines = false;
                map.Cursor = Cursors.Default;
            }
        }
        private void LoadOrCreatePointLayer()
        {
            // 创建一个新的点图层
            FeatureSet featureSet = new FeatureSet(FeatureType.Point);
            featureSet.Projection = map.Projection;

            // 定义属性字段（示例：名称、ID）
            featureSet.DataTable.Columns.Add("Name", typeof(string));
            featureSet.DataTable.Columns.Add("ID", typeof(int));

            // 添加到地图并开始编辑
            editingLayer = map.Layers.Add(featureSet);
            //editingLayer.DataSet.StartEditing();
        }
        private void 添加点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (editingLayer == null)
            {
                MessageBox.Show("请先加载或创建一个可编辑的矢量图层！");
                return;
            }

            isAddingPoints = true;
            map.Cursor = Cursors.Cross; // 鼠标变为十字准星
            MessageBox.Show("点击地图添加点，右键退出添加模式。");

        }
        private void SaveEdits()
        {
            if (editingLayer == null) return;

            saveFileDialog.Filter = "Shapefile (*.shp)|*.shp";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                editingLayer.DataSet.SaveAs(saveFileDialog.FileName, true);
                //editingLayer.DataSet.(true); // 保存并结束编辑
                // if (editingLayer is IEditableLayer editableLayer)
                // {
                //   editableLayer.EndEdit();
                // }

                MessageBox.Show("保存成功！");
            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            StartEditing(editingLayer);//开始编辑
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SaveEdits();//保持编辑
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            base.OnLoad(e);
            LoadOrCreatePointLayer();
            UpdateLayerList();//创建矢量图层
        }
        private void legend1_Click(object sender, EventArgs e)
        {

        }
        // 更新图层列表
        private void UpdateLayerList()
        {
            lstlayers.Items.Clear();
            foreach (var layer in map.Layers.Reverse())
            {
                var item = new ListViewItem(layer.LegendText)
                {
                    Checked = layer.IsVisible,
                    Tag = layer
                };
                lstlayers.Items.Add(item);
            }
        }

        private void lstlayers_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e.Item.Tag is IMapLayer layer)
            {
                layer.IsVisible = e.Item.Checked;
                map.Refresh();
            }

        }
        private void lstlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstlayers.SelectedItems.Count > 0)
            {
                _selectedLayer = lstlayers.SelectedItems[0].Tag as IMapLayer;
            }
        }

        private void 删除所选要素ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_selectedLayer is IMapFeatureLayer featureLayer)
            {
                var features = featureLayer.Selection.ToFeatureList();
                foreach (var feature in features)
                {
                    featureLayer.DataSet.Features.Remove(feature);
                }
                map.ResetBuffer();
                map.Refresh();
                UpdateLayerList();
            }
        }



        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (lstlayers.SelectedItems.Count > 0)
            {
                var layer = lstlayers.SelectedItems[0].Tag as IMapLayer;
                map.Layers.Remove(layer);
                UpdateLayerList();
                map.Refresh();
            }
        }

        private void 缓冲区分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (map.Layers.Count == 0)
            {
                MessageBox.Show("请先加载一个shp文件。");
                return;
            }

            IFeatureLayer lineLayer = map.Layers[0] as IFeatureLayer;
            if (lineLayer == null)
            {
                MessageBox.Show("无效的图层。");
                return;
            }
            string s = Interaction.InputBox("设置缓冲区距离", "缓冲区距离", "10.0", -1, -1);
            double bufferDistance;
            try
            {
                bufferDistance = Double.Parse(s);
            }
            catch (FormatException)
            { MessageBox.Show("无效的距离"); return; }
            IFeatureSet bufferFeatureSet = lineLayer.DataSet.Buffer(bufferDistance, true);
            MapPolygonLayer bufferLayer = new MapPolygonLayer(bufferFeatureSet)
            {
                Symbolizer = new PolygonSymbolizer(System.Drawing.Color.FromArgb(128, System.Drawing.Color.Red))
            };
            map.Layers.Add(bufferLayer);
            map.ZoomToMaxExtent();
            UpdateLayerList();
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (editingLayer == null)
            {
                MessageBox.Show("请先加载或创建一个可编辑的矢量图层！");
                return;
            }
        }
    }

}
