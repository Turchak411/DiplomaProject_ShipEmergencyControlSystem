using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ShipEmergencyControlSystem
{
    public class GraphicManager
    {
        // Graphics values:
        private string m_dataPath;
        private Section[] m_sideIceSection;
        private int m_currentSectionLayerShow;

        private int m_graphicScaling;

        // Animation values:
        private int m_currentShipLayer;
        private PictureBox m_pictureShip;

        // Section-Speed Graphic:
        private SectionGraphic m_sectionGraphic;

        private GraphicManager() { }

        public GraphicManager(string dataPath, int sectionLayerShow, int graphicScaling, PictureBox pictureShip)
        {
            m_dataPath = dataPath;
            // Данных о 5 разрезах льда: (Пять линий движения)
            m_sideIceSection = new Section[7];
            m_currentSectionLayerShow = sectionLayerShow;
            m_graphicScaling = graphicScaling;

            m_currentShipLayer = 3;
            m_pictureShip = pictureShip;
            RefreshShipByLayer();

            m_sectionGraphic = new SectionGraphic();

            LoadData();
        }

        private void LoadData()
        {
            // Загрузка данных ледового поля:
            using (StreamReader fileReader = new StreamReader(m_dataPath))
            {
                // Объявление первого массива:
                m_sideIceSection[0] = new Section(new List<Point>());

                for(int i = 0, k = 0; !fileReader.EndOfStream; k++)
                { 
                    string[] pointString = fileReader.ReadLine().Split(' ');

                    if(pointString[0] == "")
                    {
                        i++;
                        k = 0;
                        m_sideIceSection[i] = new Section(new List<Point>());
                        pointString = fileReader.ReadLine().Split(' ');
                    }

                    double pointX = Convert.ToDouble(pointString[0]);
                    double pointY = Convert.ToDouble(pointString[1]);

                    m_sideIceSection[i]._pointList.Add(new Point(pointX, pointY));
                }
            }
        }

        public void DrawProgressBar(PictureBox pictureBox)
        {
            Bitmap flag = new Bitmap(pictureBox.Width, pictureBox.Height);
            Graphics sideIceSection = Graphics.FromImage(flag);

            // Drawing waterlevel:
            sideIceSection.DrawLine(new Pen(Color.Black, 2), 0, 25, pictureBox.Width, 25);

            pictureBox.Image = flag;
        }

        public void DrawSideGraphic(PictureBox pictureBox)
        {
            Pen penBlack = new Pen(Color.Black, 3);

            // Система Координат
            Bitmap flag = new Bitmap(pictureBox.Width, pictureBox.Height);
            Graphics sideIceSection = Graphics.FromImage(flag);

            // Drawing graphic:
            for (int i = 0; i < m_sideIceSection[m_currentSectionLayerShow]._pointList.Count - 1; i++)
            {
                double x1 = m_sideIceSection[m_currentSectionLayerShow]._pointList[i]._x;
                double y1 = m_sideIceSection[m_currentSectionLayerShow]._pointList[i]._y;

                double x2 = m_sideIceSection[m_currentSectionLayerShow]._pointList[i + 1]._x;
                double y2 = m_sideIceSection[m_currentSectionLayerShow]._pointList[i + 1]._y;

                x1 = x1 * m_graphicScaling;
                y1 = y1 * m_graphicScaling + 120;
                x2 = x2 * m_graphicScaling;
                y2 = y2 * m_graphicScaling + 120;

                sideIceSection.DrawLine(penBlack,
                                        (int)(x1),
                                        (int)(y1),
                                        (int)(x2),
                                        (int)(y2));
            }

            pictureBox.Image = flag;
        }

        public void DrawAboveGraphic(PictureBox pictureBox)
        {
            // Drawing graphic:
            Bitmap bitmapImage = new Bitmap(pictureBox.Width, pictureBox.Height);
            Graphics sideIceSection = Graphics.FromImage(bitmapImage);

            int lineIndentY = 55;
            int picDecrease = 20;

            for (int i = 1; i < m_sideIceSection.Length - 1; i++)
            {
                for (int k = 0; k < m_sideIceSection[i]._pointList.Count; k++)
                {
                    if (m_sideIceSection[i]._pointList[k]._y < -0.60)
                    {
                        int locationX = (int)(m_sideIceSection[i]._pointList[k]._x * m_graphicScaling);
                        sideIceSection.DrawImage(Properties.Resources.alert, locationX - picDecrease / 2, (i - 1) * lineIndentY + 10, picDecrease, picDecrease);
                    }
                }
            }

            pictureBox.Image = bitmapImage;
        }

        public void RefreshShipByLayer()
        {
            switch(m_currentShipLayer)
            {
                case 1:
                    m_pictureShip.Top = 276;
                    break;
                case 2:
                    m_pictureShip.Top = 331;
                    break;
                case 3:
                    m_pictureShip.Top = 386;
                    break;
                case 4:
                    m_pictureShip.Top = 441;
                    break;
                case 5:
                    m_pictureShip.Top = 496;
                    break;
                default:
                    break;
            }
        }

        public double[] AnalyzeEnvironment()
        {
            // 1.5 m of ice thickness = 0.2 conventional units
            double permissibleThickness = 0.8;

            double[] environmentThickness = new double[4];

            // Getting ship location (x) in graph metrix (without graphic scaling):
            double currentShipLocationX = (m_pictureShip.Left - 299) / m_graphicScaling;

            // Scan 1 point ship overline:
            environmentThickness[0] = (GetIceThicknessByLocation(currentShipLocationX + 1.8, m_currentShipLayer - 1) < permissibleThickness) ? 1 : 0;

            // Scan 2 points ship forward:
            environmentThickness[1] = (GetIceThicknessByLocation(currentShipLocationX, m_currentShipLayer) < permissibleThickness) ? 1 : 0;
            environmentThickness[2] = (GetIceThicknessByLocation(currentShipLocationX + 1.8, m_currentShipLayer) < permissibleThickness) ? 1 : 0;

            // Scan 1 point ship underline:
            environmentThickness[3] = (GetIceThicknessByLocation(currentShipLocationX + 1.8, m_currentShipLayer + 1) < permissibleThickness) ? 1 : 0;

            return environmentThickness;
        }

        private double GetIceThicknessByLocation(double x, int lineY)
        {
            // Получение толщины в долях ([0.0 ; 1.0])
            for(int i = 0; i < m_sideIceSection[lineY]._pointList.Count - 1; i++)
            {
                if(x <= m_sideIceSection[lineY]._pointList[i + 1]._x && x >= m_sideIceSection[lineY]._pointList[i]._x)
                {
                    return 1 - (m_sideIceSection[lineY]._pointList[i]._y + 1) / 2;
                }
            }

            return 0; // zero thickness
        }

        public void TurnShipRight()
        {
            m_currentShipLayer++;
            m_currentSectionLayerShow++;
            RefreshShipByLayer();  
        }

        public void TurnShipLeft()
        {
            m_currentShipLayer--;
            m_currentSectionLayerShow--;
            RefreshShipByLayer();
        }

        public void RefreshSectionGraphic(System.Windows.Forms.DataVisualization.Charting.Chart graphicThickness, System.Windows.Forms.DataVisualization.Charting.Chart graphicSpeed)
        {
            // Getting ship location (x) in graph metrix (without graphic scaling):
            double currentShipLocationX = (m_pictureShip.Left - 299) / m_graphicScaling;

            // Get AVG value along the ship length:
            double[] environmentThickness = new double[4];

            environmentThickness[0] = GetIceThicknessByLocation(currentShipLocationX, m_currentShipLayer);
            environmentThickness[1] = GetIceThicknessByLocation(currentShipLocationX + 0.5, m_currentShipLayer);
            environmentThickness[2] = GetIceThicknessByLocation(currentShipLocationX + 1, m_currentShipLayer);
            environmentThickness[3] = GetIceThicknessByLocation(currentShipLocationX + 1.5, m_currentShipLayer);

            double avgThicknessValue = GetArrayAVG(environmentThickness);

            m_sectionGraphic.Refresh(graphicThickness, graphicSpeed, avgThicknessValue);
        }

        private double GetArrayAVG(double[] arrayValues)
        {
            double sum = 0;

            for(int i = 0; i < arrayValues.Length; i++)
            {
                sum += arrayValues[i];
            }

            return sum / arrayValues.Length;
        }

        public double GetSpeedValue()
        {
            return m_sectionGraphic.GetSpeed();
        }

    }

    public struct Section
    {
        public List<Point> _pointList;

        public Section(List<Point> pointList)
        {
            _pointList = pointList;
        }
    }

    public struct Point
    {
        public double _x;
        public double _y;

        public Point(double x, double y)
        {
            _x = x;
            _y = y;
        }
    }
}
