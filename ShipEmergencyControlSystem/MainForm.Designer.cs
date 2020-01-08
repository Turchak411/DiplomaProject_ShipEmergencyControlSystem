namespace ShipEmergencyControlSystem
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label_speedInfo = new System.Windows.Forms.Label();
            this.groupBox_shipState = new System.Windows.Forms.GroupBox();
            this.label_speed = new System.Windows.Forms.Label();
            this.btn_StartSimulation = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.actionTimer = new System.Windows.Forms.Timer(this.components);
            this.label_info_progress = new System.Windows.Forms.Label();
            this.label_sectionThicknessGraphicInfo = new System.Windows.Forms.Label();
            this.chart_sectionThicknessGraphic = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart_speedGraphic = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label_sectionSpeedGraphicInfo = new System.Windows.Forms.Label();
            this.label_typeOfShipInfo = new System.Windows.Forms.Label();
            this.pictureBox_shipAbove = new System.Windows.Forms.PictureBox();
            this.pictureBox_mainGraphic_above = new System.Windows.Forms.PictureBox();
            this.pictureBox_shipSide = new System.Windows.Forms.PictureBox();
            this.pictureBox_mainGraphic_side = new System.Windows.Forms.PictureBox();
            this.pictureBox_progressBar = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox_shipState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_sectionThicknessGraphic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_speedGraphic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_shipAbove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_mainGraphic_above)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_shipSide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_mainGraphic_side)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_progressBar)).BeginInit();
            this.SuspendLayout();
            // 
            // label_speedInfo
            // 
            this.label_speedInfo.AutoSize = true;
            this.label_speedInfo.Location = new System.Drawing.Point(22, 32);
            this.label_speedInfo.Name = "label_speedInfo";
            this.label_speedInfo.Size = new System.Drawing.Size(58, 13);
            this.label_speedInfo.TabIndex = 0;
            this.label_speedInfo.Text = "Скорость:";
            // 
            // groupBox_shipState
            // 
            this.groupBox_shipState.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox_shipState.Controls.Add(this.label_speed);
            this.groupBox_shipState.Controls.Add(this.label_speedInfo);
            this.groupBox_shipState.Location = new System.Drawing.Point(12, 98);
            this.groupBox_shipState.Name = "groupBox_shipState";
            this.groupBox_shipState.Size = new System.Drawing.Size(218, 68);
            this.groupBox_shipState.TabIndex = 4;
            this.groupBox_shipState.TabStop = false;
            this.groupBox_shipState.Text = "Состояние судна:";
            // 
            // label_speed
            // 
            this.label_speed.AutoSize = true;
            this.label_speed.Location = new System.Drawing.Point(86, 32);
            this.label_speed.Name = "label_speed";
            this.label_speed.Size = new System.Drawing.Size(48, 13);
            this.label_speed.TabIndex = 1;
            this.label_speed.Text = "<speed>";
            // 
            // btn_StartSimulation
            // 
            this.btn_StartSimulation.Location = new System.Drawing.Point(12, 55);
            this.btn_StartSimulation.Name = "btn_StartSimulation";
            this.btn_StartSimulation.Size = new System.Drawing.Size(218, 37);
            this.btn_StartSimulation.TabIndex = 6;
            this.btn_StartSimulation.Text = "Старт симуляции";
            this.btn_StartSimulation.UseVisualStyleBackColor = true;
            this.btn_StartSimulation.Click += new System.EventHandler(this.btn_StartSimulation_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(12, 896);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 23);
            this.btn_exit.TabIndex = 7;
            this.btn_exit.Text = "Выход";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // actionTimer
            // 
            this.actionTimer.Tick += new System.EventHandler(this.actionTimer_Tick);
            // 
            // label_info_progress
            // 
            this.label_info_progress.AutoSize = true;
            this.label_info_progress.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.label_info_progress.Location = new System.Drawing.Point(244, 21);
            this.label_info_progress.Name = "label_info_progress";
            this.label_info_progress.Size = new System.Drawing.Size(44, 18);
            this.label_info_progress.TabIndex = 14;
            this.label_info_progress.Text = "Ход:";
            // 
            // label_sectionThicknessGraphicInfo
            // 
            this.label_sectionThicknessGraphicInfo.AutoSize = true;
            this.label_sectionThicknessGraphicInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_sectionThicknessGraphicInfo.Location = new System.Drawing.Point(8, 633);
            this.label_sectionThicknessGraphicInfo.Name = "label_sectionThicknessGraphicInfo";
            this.label_sectionThicknessGraphicInfo.Size = new System.Drawing.Size(280, 18);
            this.label_sectionThicknessGraphicInfo.TabIndex = 17;
            this.label_sectionThicknessGraphicInfo.Text = "График изменения толщины льда:";
            // 
            // chart_sectionThicknessGraphic
            // 
            chartArea1.Name = "ChartArea1";
            this.chart_sectionThicknessGraphic.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_sectionThicknessGraphic.Legends.Add(legend1);
            this.chart_sectionThicknessGraphic.Location = new System.Drawing.Point(299, 554);
            this.chart_sectionThicknessGraphic.Name = "chart_sectionThicknessGraphic";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series1.Legend = "Legend1";
            series1.Name = "Толщина льда";
            series1.YValuesPerPoint = 4;
            this.chart_sectionThicknessGraphic.Series.Add(series1);
            this.chart_sectionThicknessGraphic.Size = new System.Drawing.Size(913, 178);
            this.chart_sectionThicknessGraphic.TabIndex = 18;
            this.chart_sectionThicknessGraphic.Text = "Section thickness chart";
            // 
            // chart_speedGraphic
            // 
            chartArea2.Name = "ChartArea1";
            this.chart_speedGraphic.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart_speedGraphic.Legends.Add(legend2);
            this.chart_speedGraphic.Location = new System.Drawing.Point(299, 741);
            this.chart_speedGraphic.Name = "chart_speedGraphic";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series2.Legend = "Legend1";
            series2.Name = "Скорость судна";
            series2.YValuesPerPoint = 4;
            this.chart_speedGraphic.Series.Add(series2);
            this.chart_speedGraphic.Size = new System.Drawing.Size(913, 178);
            this.chart_speedGraphic.TabIndex = 19;
            this.chart_speedGraphic.Text = "Speed chart";
            // 
            // label_sectionSpeedGraphicInfo
            // 
            this.label_sectionSpeedGraphicInfo.AutoSize = true;
            this.label_sectionSpeedGraphicInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_sectionSpeedGraphicInfo.Location = new System.Drawing.Point(9, 820);
            this.label_sectionSpeedGraphicInfo.Name = "label_sectionSpeedGraphicInfo";
            this.label_sectionSpeedGraphicInfo.Size = new System.Drawing.Size(240, 18);
            this.label_sectionSpeedGraphicInfo.TabIndex = 20;
            this.label_sectionSpeedGraphicInfo.Text = "График изменения скорости:";
            // 
            // label_typeOfShipInfo
            // 
            this.label_typeOfShipInfo.AutoSize = true;
            this.label_typeOfShipInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_typeOfShipInfo.Location = new System.Drawing.Point(12, 21);
            this.label_typeOfShipInfo.Name = "label_typeOfShipInfo";
            this.label_typeOfShipInfo.Size = new System.Drawing.Size(151, 18);
            this.label_typeOfShipInfo.TabIndex = 21;
            this.label_typeOfShipInfo.Text = "Тип судна: Танкер";
            // 
            // pictureBox_shipAbove
            // 
            this.pictureBox_shipAbove.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_shipAbove.Image = global::ShipEmergencyControlSystem.Properties.Resources.ship_above;
            this.pictureBox_shipAbove.Location = new System.Drawing.Point(299, 329);
            this.pictureBox_shipAbove.Name = "pictureBox_shipAbove";
            this.pictureBox_shipAbove.Size = new System.Drawing.Size(110, 37);
            this.pictureBox_shipAbove.TabIndex = 13;
            this.pictureBox_shipAbove.TabStop = false;
            // 
            // pictureBox_mainGraphic_above
            // 
            this.pictureBox_mainGraphic_above.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pictureBox_mainGraphic_above.BackgroundImage = global::ShipEmergencyControlSystem.Properties.Resources.re;
            this.pictureBox_mainGraphic_above.Image = global::ShipEmergencyControlSystem.Properties.Resources.re;
            this.pictureBox_mainGraphic_above.Location = new System.Drawing.Point(299, 272);
            this.pictureBox_mainGraphic_above.Name = "pictureBox_mainGraphic_above";
            this.pictureBox_mainGraphic_above.Size = new System.Drawing.Size(913, 266);
            this.pictureBox_mainGraphic_above.TabIndex = 12;
            this.pictureBox_mainGraphic_above.TabStop = false;
            // 
            // pictureBox_shipSide
            // 
            this.pictureBox_shipSide.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_shipSide.Image = global::ShipEmergencyControlSystem.Properties.Resources.ship_side;
            this.pictureBox_shipSide.Location = new System.Drawing.Point(299, 12);
            this.pictureBox_shipSide.Name = "pictureBox_shipSide";
            this.pictureBox_shipSide.Size = new System.Drawing.Size(110, 37);
            this.pictureBox_shipSide.TabIndex = 8;
            this.pictureBox_shipSide.TabStop = false;
            // 
            // pictureBox_mainGraphic_side
            // 
            this.pictureBox_mainGraphic_side.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pictureBox_mainGraphic_side.Location = new System.Drawing.Point(299, 55);
            this.pictureBox_mainGraphic_side.Name = "pictureBox_mainGraphic_side";
            this.pictureBox_mainGraphic_side.Size = new System.Drawing.Size(913, 211);
            this.pictureBox_mainGraphic_side.TabIndex = 9;
            this.pictureBox_mainGraphic_side.TabStop = false;
            // 
            // pictureBox_progressBar
            // 
            this.pictureBox_progressBar.BackColor = System.Drawing.Color.White;
            this.pictureBox_progressBar.Location = new System.Drawing.Point(299, 12);
            this.pictureBox_progressBar.Name = "pictureBox_progressBar";
            this.pictureBox_progressBar.Size = new System.Drawing.Size(913, 37);
            this.pictureBox_progressBar.TabIndex = 15;
            this.pictureBox_progressBar.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Вид ледового поля: Т";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 927);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_typeOfShipInfo);
            this.Controls.Add(this.label_sectionSpeedGraphicInfo);
            this.Controls.Add(this.chart_speedGraphic);
            this.Controls.Add(this.chart_sectionThicknessGraphic);
            this.Controls.Add(this.label_sectionThicknessGraphicInfo);
            this.Controls.Add(this.label_info_progress);
            this.Controls.Add(this.pictureBox_shipAbove);
            this.Controls.Add(this.pictureBox_shipSide);
            this.Controls.Add(this.pictureBox_mainGraphic_side);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_StartSimulation);
            this.Controls.Add(this.groupBox_shipState);
            this.Controls.Add(this.pictureBox_progressBar);
            this.Controls.Add(this.pictureBox_mainGraphic_above);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ship Emergency Control System v0.1";
            this.groupBox_shipState.ResumeLayout(false);
            this.groupBox_shipState.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_sectionThicknessGraphic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_speedGraphic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_shipAbove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_mainGraphic_above)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_shipSide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_mainGraphic_side)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_progressBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_speedInfo;
        private System.Windows.Forms.GroupBox groupBox_shipState;
        private System.Windows.Forms.Button btn_StartSimulation;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Label label_speed;
        private System.Windows.Forms.Timer actionTimer;
        private System.Windows.Forms.PictureBox pictureBox_shipSide;
        private System.Windows.Forms.PictureBox pictureBox_mainGraphic_side;
        private System.Windows.Forms.PictureBox pictureBox_mainGraphic_above;
        private System.Windows.Forms.PictureBox pictureBox_shipAbove;
        private System.Windows.Forms.Label label_info_progress;
        private System.Windows.Forms.PictureBox pictureBox_progressBar;
        private System.Windows.Forms.Label label_sectionThicknessGraphicInfo;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_sectionThicknessGraphic;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_speedGraphic;
        private System.Windows.Forms.Label label_sectionSpeedGraphicInfo;
        private System.Windows.Forms.Label label_typeOfShipInfo;
        private System.Windows.Forms.Label label1;
    }
}

