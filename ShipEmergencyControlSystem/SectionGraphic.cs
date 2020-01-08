using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShipEmergencyControlSystem
{
    public class SectionGraphic
    {
        private int m_currentGraphicPosX;
        private double m_currentSpeed;

        public SectionGraphic()
        {
            m_currentGraphicPosX = 0;
        }

        public void Refresh(System.Windows.Forms.DataVisualization.Charting.Chart graphicThickness, System.Windows.Forms.DataVisualization.Charting.Chart graphicSpeed, double valueY)
        {
            // Refresh thickness graphic:
            graphicThickness.Series[0].Points.AddXY(m_currentGraphicPosX, valueY);

            // Refresh speed graphic:
            // Calculate speed by thickness:
            double maxSpeed = 29.632;   // 16 узлов
            double iceH = valueY;
            double maxIceH = 0.6;
            double k = 1.055; // Коэффициент, характеризующий снижение скорости судна за счет сопротивления ледового поля.
            m_currentSpeed = (1 - k * Math.Pow(iceH / maxIceH, 3)) * maxSpeed;

            graphicSpeed.Series[0].Points.AddXY(m_currentGraphicPosX, m_currentSpeed);

            // Update posX value:
            m_currentGraphicPosX++;
        }

        public double GetSpeed()
        {
            return m_currentSpeed;
        }
    }
}
