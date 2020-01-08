using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShipEmergencyControlSystem
{
    public partial class MainForm : Form
    {
        private NeuralNetwork m_network;
        private FileManager m_fileManager;
        private GraphicManager m_graphicManager;

        private int m_shipSpeed;

        public MainForm()
        {
            InitializeComponent();
            InitializeNetwork();
            InitializeGraphics("iceSection.txt", 3);
            m_shipSpeed = 2;
        }

        private void InitializeGraphics(string dataPath, int sectionLayer)
        {
            // Создание графиков:
            m_graphicManager = new GraphicManager(dataPath, sectionLayer, 75, pictureBox_shipAbove);
            // Создание линии пройденного пути:
            m_graphicManager.DrawProgressBar(pictureBox_progressBar);
            m_graphicManager.DrawSideGraphic(pictureBox_mainGraphic_side);
            m_graphicManager.DrawAboveGraphic(pictureBox_mainGraphic_above);
        }

        private void RedrawSideGraphic()
        {
            m_graphicManager.DrawSideGraphic(pictureBox_mainGraphic_side);
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void InitializeNetwork()
        {
            // Prepare creating data:
            int[] neuronsScheme = new int[3] { 3, 3, 3 };
            // 3 - on input layer
            // 3 - on #0 hidden layer
            // 3 - on output layer
            int receptorsNumber = 4;

            // Creating clear net memory:
            string memoryFileName = "memory.txt";

            /*
            if(File.Exists(memoryFileName))
            {
                File.Delete(memoryFileName);
            }
            */

            MemoryGenerator m_memoryGenerator = new MemoryGenerator();
            //m_memoryGenerator.GenerateMemory(receptorsNumber, neuronsScheme, memoryFileName);

            // Creating file manager:
            m_fileManager = new FileManager(memoryFileName);

            // Creating net:
            m_network = new NeuralNetwork(neuronsScheme, receptorsNumber, m_fileManager);

            // Training network:
            TrainNet();
        }

        private void TrainNet()
        {
            // Get/create data:

            // Поворот направо:
            double[] dataSet0 = new double[4] { 0.0, 0.0, 0.0, 1.0 };

            // Поворот налево:
            double[] dataSet1 = new double[4] { 1.0, 0.0, 0.0, 0.0};

            // Сохранение направления движения:
            double[] dataSet2 = new double[4] { 0.0, 1.0, 1.0, 0.0 };
            double[] dataSet3 = new double[4] { 0.5, 1.0, 1.0, 0.5 };
            double[] dataSet4 = new double[4] { 0.5, 1.0, 1.0, 0.0 };
            double[] dataSet5 = new double[4] { 0.0, 1.0, 1.0, 0.5 };

            double[][] dataSet = new double[6][] { dataSet0, dataSet1, dataSet2, dataSet3, dataSet4, dataSet5 };
            double[][] dataSetAnwsers = new double[6][] { new double[3] { 1, 0, 0 },

                                                          new double[3] { 0, 1, 0 },

                                                          new double[3] { 0, 0, 1 },
                                                          new double[3] { 0, 0, 1 },
                                                          new double[3] { 0, 0, 1 },
                                                          new double[3] { 0, 0, 1 }
                                                        };

            // Train net:
            Console.WriteLine("Training net...");

            double learningSpeed = 0;

            try
            {
                // Batch Normalization
                // 64.000 iterations ~ 80 % accuracy
                // 420.000 iterations ~	94.5% accuracy
                for (int i = 0; i < 420000; i++)
                {
                    // Пересчет величины скорости обучения:
                    learningSpeed = 0.01 * Math.Pow(0.1, i / 150000);

                    for (int k = 0; k < dataSet.Length; k++)
                    {
                        m_network.Handle(dataSet[k]);
                        m_network.Teach(dataSet[k], dataSetAnwsers[k], learningSpeed);
                    }
                }

                Console.WriteLine("Training success!");
            }
            catch
            {
                Console.WriteLine("Training failed!");
            }

            // Save network memory:
            m_network.SaveMemory(m_fileManager);
        }

        private void btn_StartSimulation_Click(object sender, EventArgs e)
        {
            actionTimer.Enabled = true;
            actionTimer.Start();

            btn_StartSimulation.Enabled = false;
        }

        private void actionTimer_Tick(object sender, EventArgs e)
        {
            pictureBox_shipSide.Left  += m_shipSpeed;
            pictureBox_shipAbove.Left += m_shipSpeed;

            // Scan ship environment:
            double[] environment = m_graphicManager.AnalyzeEnvironment();

            // Get anwser from network:
            double[] anwserVector = m_network.Handle(environment);
            // TODO Возможно, сделать отображение решений в логах (мб при открытии их на форме на спец. кнопку)

            // Handle network anwser:
            HandleNetAnwser(anwserVector);

            // Refresh section-speed graphic:
            m_graphicManager.RefreshSectionGraphic(chart_sectionThicknessGraphic, chart_speedGraphic);

            // Refresh speed label:
            label_speed.Text = String.Format("{0:f0} км/ч", m_graphicManager.GetSpeedValue());

            // Refresh side graphic:
            RedrawSideGraphic();

            // For testing:
            for (int i = 0; i < anwserVector.Length; i++)
            {
                Console.WriteLine("{0:f6}", anwserVector[i]);
            }
            Console.WriteLine();
        }

        private void HandleNetAnwser(double[] anwserVector)
        {
            int maxValueIndex = GetMaxValueIndex(anwserVector);

            switch (maxValueIndex)
            {
                // Поворот направо:
                case 0:
                    m_graphicManager.TurnShipRight();
                    break;
                // Поворот налево:
                case 1:
                    m_graphicManager.TurnShipLeft();
                    break;
                // Сохранение направления движения:
                case 2:
                default:
                    break;
            }
        }

        private int GetMaxValueIndex(double[] vector)
        {
            int maxIndex = 0;
            double maxValue = vector[maxIndex];

            for(int i = 1; i < vector.Length; i++)
            {
                if(vector[i] > maxValue)
                {
                    maxIndex = i;
                    maxValue = vector[i];
                }
            }

            return maxIndex;
        }

        //private void numericUpDown_iceSection_ValueChanged(object sender, EventArgs e)
        //{
        //    //InitializeGraphics("iceSection.txt", (int)numericUpDown_iceSection.Value);
        //}
    }
}
