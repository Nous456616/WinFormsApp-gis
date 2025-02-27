using DotSpatial.Controls;
using DotSpatial.Data;
using DotSpatial.Symbology;
using DotSpatial.Projections;
using DotSpatial.Data.Forms;
using System.Drawing;
using NetTopologySuite.Geometries;
using System;
using System.Windows.Forms;
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private IMapFeatureLayer editingLayer;
        private bool isAddingPoints = false;   // 是否处于添加点模式
        private Map map;
        private SaveFileDialog saveFileDialog = new SaveFileDialog();
        public Form1()
        {
            InitializeComponent();
            InitializeMap();
            this.DoubleBuffered = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void InitializeMap()
        {
            map = new Map
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(map);
            map.MouseClick += Map_MouseClick;

            // 设置地图的投影
            map.Projection = KnownCoordinateSystems.Projected.World.WebMercator;
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

                map.ResetBuffer();
            }
        }

        private void tiffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "TIFF文件 (*.tif)|*.tif"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                IRaster raster = Raster.Open(dialog.FileName);
                IMapRasterLayer layer = map.Layers.Add(raster);

                // 设置颜色方案（示例：灰度渲染）
                layer.Symbolizer = new RasterSymbolizer
                {

                };

                map.ResetBuffer();
            }

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
        private void Map_MouseClick(object sender, MouseEventArgs e)
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
        private void LoadOrCreatePointLayer()
        {
            // 示例：创建一个新的点图层
            FeatureSet featureSet = new FeatureSet(FeatureType.Point);
            featureSet.Projection = map.Projection;

            // 定义属性字段（示例：名称、ID）
            featureSet.DataTable.Columns.Add("Name", typeof(string));
            featureSet.DataTable.Columns.Add("ID", typeof(int));

            // 添加到地图并开始编辑
            editingLayer = map.Layers.Add(featureSet) as IMapFeatureLayer;
            editingLayer.DataSet.StartEditing();
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
                if (editingLayer is IEditableLayer editableLayer)
                {
                    editableLayer.EndEdit();
                }

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
            LoadOrCreatePointLayer(); // 在窗体加载时创建一个示例图层
        }
    }

}
