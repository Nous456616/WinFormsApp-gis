using DotSpatial.Controls;
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
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private IMapFeatureLayer editingLayer;
        private bool isAddingPoints = false;   // �Ƿ�����ӵ�ģʽ
        private bool isAddinglines = false;   // �Ƿ��������ģʽ
        private Map map;
        private SaveFileDialog saveFileDialog = new SaveFileDialog();
        private IMapLayer _selectedLayer;
       

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

            // ���õ�ͼ��ͶӰ
            map.Projection = KnownCoordinateSystems.Projected.World.WebMercator;
        }


        private void �Ŵ�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            map.FunctionMode = FunctionMode.ZoomIn;
        }

        private void ��СToolStripMenuItem_Click(object sender, EventArgs e)
        {
            map.FunctionMode = FunctionMode.ZoomOut;
        }

        private void ȫ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            map.ZoomToMaxExtent();
        }
        private void ѡ��ToolStripMenuItem_Click(object sender, EventArgs e)
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

                // ���÷�����ʽ��ʾ������ɫ�߿����Σ�
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

        private void tiffToolStripMenuItem_Click(object sender, EventArgs e)//tif�ļ�
        {
            using(OpenFileDialog ofd = new OpenFileDialog())
        {
                ofd.Filter = "TIFF Files (*.tif;*.tiff)|*.tif;*.tiff";
                ofd.Title = "ѡ��դ���ļ�";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // ʹ��Raster.Open��ȡ����ο����ݣ��Ƽ���ʽ��
                        IRaster raster = Raster.Open(ofd.FileName);

                        // ���դ��ͼ�㵽��ͼ
                        map.Layers.Add(raster);

                        // �Զ�������ͼ�㷶Χ
                        map.ZoomToMaxExtent();

                        // ����ͼ���б�
                        UpdateLayerList();

                        MessageBox.Show("TIFF���سɹ�");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"����ʧ��: {ex.Message}");
                    }
                }
            }
        }

        private void ƽ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            map.FunctionMode = FunctionMode.Pan;
        }
        private void StartEditing(IMapFeatureLayer layer)
        {
            editingLayer = layer;

            map.FunctionMode = FunctionMode.Select; // �л���ѡ��ģʽ
        }
        private void Map_MouseClick(object sender, MouseEventArgs e)//��ӵ�
        {
            if (!isAddingPoints || editingLayer == null) return;

            if (e.Button == MouseButtons.Left)
            {
                // �����λ��ת��Ϊ��ͼ����
                Coordinate coord = map.PixelToProj(e.Location);

                // ʹ�� NetTopologySuite.Geometries.Point
                NetTopologySuite.Geometries.Point point = new NetTopologySuite.Geometries.Point(coord.X, coord.Y);

                // ������ӵ�ͼ��
                IFeature feature = editingLayer.DataSet.AddFeature(point);

                // ���õ����ʾ��ʽ����ɫԲ�Σ���С8���أ�
                if (editingLayer.Symbology == null)
                {
                    // ʹ�� DotSpatial.Symbology.PointShape
                    var symbolizer = new PointSymbolizer(Color.Red, DotSpatial.Symbology.PointShape.Ellipse, 8);
                    editingLayer.Symbology = new PointScheme { Categories = { new PointCategory(symbolizer) } };
                }

                map.ResetBuffer(); // ˢ�µ�ͼ
            }
            else if (e.Button == MouseButtons.Right)
            {
                isAddingPoints = false;
                map.Cursor = Cursors.Default;
            }
        }
        private void Map_MouseChick_1(object sender, MouseEventArgs e)//�����
        {
            if (!isAddinglines || editingLayer == null) return;
            if (e.Button == MouseButtons.Left)
            {
                // �����λ��ת��Ϊ��ͼ����
                Coordinate coord = map.PixelToProj(e.Location);
                // ʹ�� NetTopologySuite.Geometries.Point
                NetTopologySuite.Geometries.Point point = new NetTopologySuite.Geometries.Point(coord.X, coord.Y);
                
                // ������ӵ�ͼ��
                IFeature feature = editingLayer.DataSet.AddFeature(point);
                // ���õ����ʾ��ʽ����ɫԲ�Σ���С8���أ�
                if (editingLayer.Symbology == null)
                {
                    // ʹ�� DotSpatial.Symbology.PointShape
                    var symbolizer = new PointSymbolizer(Color.Red, DotSpatial.Symbology.PointShape.Ellipse, 8);
                    editingLayer.Symbology = new PointScheme { Categories = { new PointCategory(symbolizer) } };
                }
                map.ResetBuffer(); // ˢ�µ�ͼ
            }
            else if (e.Button == MouseButtons.Right)
            {
                isAddinglines = false;
                map.Cursor = Cursors.Default;
            }
        }
        private void LoadOrCreatePointLayer()
        {
            // ����һ���µĵ�ͼ��
            FeatureSet featureSet = new FeatureSet(FeatureType.Point);
            featureSet.Projection = map.Projection;

            // ���������ֶΣ�ʾ�������ơ�ID��
            featureSet.DataTable.Columns.Add("Name", typeof(string));
            featureSet.DataTable.Columns.Add("ID", typeof(int));

            // ��ӵ���ͼ����ʼ�༭
            editingLayer = map.Layers.Add(featureSet);
            //editingLayer.DataSet.StartEditing();
        }
        private void ��ӵ�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (editingLayer == null)
            {
                MessageBox.Show("���ȼ��ػ򴴽�һ���ɱ༭��ʸ��ͼ�㣡");
                return;
            }

            isAddingPoints = true;
            map.Cursor = Cursors.Cross; // ����Ϊʮ��׼��
            MessageBox.Show("�����ͼ��ӵ㣬�Ҽ��˳����ģʽ��");

        }
        private void SaveEdits()
        {
            if (editingLayer == null) return;

            saveFileDialog.Filter = "Shapefile (*.shp)|*.shp";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                editingLayer.DataSet.SaveAs(saveFileDialog.FileName, true);
                //editingLayer.DataSet.(true); // ���沢�����༭
                // if (editingLayer is IEditableLayer editableLayer)
                // {
                //   editableLayer.EndEdit();
                // }

                MessageBox.Show("����ɹ���");
            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            StartEditing(editingLayer);//��ʼ�༭
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SaveEdits();//���ֱ༭
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            base.OnLoad(e);
            LoadOrCreatePointLayer();
            UpdateLayerList();//����ʸ��ͼ��
        }
        private void legend1_Click(object sender, EventArgs e)
        {

        }
        // ����ͼ���б�
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

        private void ɾ����ѡҪ��ToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void ����������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (map.Layers.Count == 0)
            {
                MessageBox.Show("���ȼ���һ��shp�ļ���");
                return;
            }

            IFeatureLayer lineLayer = map.Layers[0] as IFeatureLayer;
            if (lineLayer == null)
            {
                MessageBox.Show("��Ч��ͼ�㡣");
                return;
            }
            string s = Interaction.InputBox("���û���������", "����������", "10.0", -1, -1);
            double bufferDistance;
            try
            {
                bufferDistance = Double.Parse(s);
            }
            catch (FormatException)
            { MessageBox.Show("��Ч�ľ���"); return; }
            IFeatureSet bufferFeatureSet = lineLayer.DataSet.Buffer(bufferDistance, true);
            MapPolygonLayer bufferLayer = new MapPolygonLayer(bufferFeatureSet)
            {
                Symbolizer = new PolygonSymbolizer(System.Drawing.Color.FromArgb(128, System.Drawing.Color.Red))
            };
            map.Layers.Add(bufferLayer);
            map.ZoomToMaxExtent();
        }

        private void ���ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (editingLayer == null)
            {
                MessageBox.Show("���ȼ��ػ򴴽�һ���ɱ༭��ʸ��ͼ�㣡");
                return;
            }
        }
    }

}
