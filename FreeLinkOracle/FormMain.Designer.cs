namespace FreeLinkOracle
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent( )
        {
            this.button1 = new System.Windows.Forms.Button( );
            this.button2 = new System.Windows.Forms.Button( );
            this.ListDept = new System.Windows.Forms.ListBox( );
            this.ButtonLoad = new System.Windows.Forms.Button( );
            this.SuspendLayout( );
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point( 664, 361 );
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size( 75, 23 );
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler( this.button1_Click );
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point( 583, 361 );
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size( 75, 23 );
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler( this.button2_Click );
            // 
            // ListDept
            // 
            this.ListDept.FormattingEnabled = true;
            this.ListDept.ItemHeight = 12;
            this.ListDept.Location = new System.Drawing.Point( 50, 43 );
            this.ListDept.Name = "ListDept";
            this.ListDept.Size = new System.Drawing.Size( 291, 280 );
            this.ListDept.TabIndex = 2;
            this.ListDept.SelectedValueChanged += new System.EventHandler( this.ListDept_SelectedValueChanged );
            // 
            // ButtonLoad
            // 
            this.ButtonLoad.Location = new System.Drawing.Point( 502, 361 );
            this.ButtonLoad.Name = "ButtonLoad";
            this.ButtonLoad.Size = new System.Drawing.Size( 75, 23 );
            this.ButtonLoad.TabIndex = 4;
            this.ButtonLoad.Text = "button3";
            this.ButtonLoad.UseVisualStyleBackColor = true;
            this.ButtonLoad.Click += new System.EventHandler( this.ButtonLoad_Click );
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 775, 410 );
            this.Controls.Add( this.ButtonLoad );
            this.Controls.Add( this.ListDept );
            this.Controls.Add( this.button2 );
            this.Controls.Add( this.button1 );
            this.Name = "FormMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler( this.FormMain_Load );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox ListDept;
        private System.Windows.Forms.Button ButtonLoad;
    }
}

