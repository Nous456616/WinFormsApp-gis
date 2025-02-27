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
        private bool isAddingPoints = false;   // �Ƿ�����ӵ�ģʽ
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

                map.ResetBuffer();
            }
        }
        private ColorScheme CreateGrayscaleScheme(double min, double max)
        {
            ColorScheme scheme = new ColorScheme();
            scheme.AddCategory(new ColorCategory(min, max, Color.Black, Color.White));
            return scheme;
        }
        private void tiffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "TIFF�ļ� (*.tif;*.tiff)|*.tif;*.tiff"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 1. ����դ������
                    IRaster raster = Raster.Open(dialog.FileName);
                    IMapRasterLayer layer = map.Layers.Add(raster);

                    // 2. ����ͳ����Ϣ��ȷ������Сֵ/���ֵ��
                    if (double.IsNaN(raster.Minimum))
                    {
                        var raster = Raster.OpenFile(dialog.FileName);
                        if (raster is Raster concreteRaster)
                        {
                            // ����һ��ֱ�ӵ��� Raster ��ļ��㷽��
                            concreteRaster.CalculateStatistics();

                            // ��������ʹ�ý���������ѡ��
                            //ProgressMeter pm = new ProgressMeter();
                            //concreteRaster.CalculateStatistics(pm);
                        }
                    }

                    // 3. �����Ҷ���ɫ��������API��ʽ��
                    RasterSymbolizer symbolizer = new RasterSymbolizer();

                    // ����һ��ֱ�����ý�����ɫ
                   // symbolizer.ColorScheme = ColorScheme.Grayscale; // ʹ�����ûҶȷ���
                    //symbolizer.ColorSchemeType = ColorSchemeType.Gradient;

                    // ���������Զ�����ɫ��Χ�����û������Grayscale��
                    symbolizer.ColorScheme = CreateGrayscaleScheme(raster.Minimum, raster.Maximum);

                    // 4. Ӧ�÷��Ż�
                    layer.Symbolizer = symbolizer;

                    // 5. ���Ų�ˢ��
                  
                    map.ResetBuffer();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"����TIFFʧ��: {ex.Message}");
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
        private void Map_MouseClick(object sender, MouseEventArgs e)
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
        private void LoadOrCreatePointLayer()
        {
            // ʾ��������һ���µĵ�ͼ��
            FeatureSet featureSet = new FeatureSet(FeatureType.Point);
            featureSet.Projection = map.Projection;

            // ���������ֶΣ�ʾ�������ơ�ID��
            featureSet.DataTable.Columns.Add("Name", typeof(string));
            featureSet.DataTable.Columns.Add("ID", typeof(int));

            // ��ӵ���ͼ����ʼ�༭
            editingLayer = map.Layers.Add(featureSet) as IMapFeatureLayer;
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
        }

        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // MapFunctionMeasure measureDistance = new MapFunctionMeasure(map);
        }
    }

}
