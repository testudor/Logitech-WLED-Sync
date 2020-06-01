using Logitech_WLED_Sync.Properties;

namespace Logitech_WLED_Sync
{
    partial class ConfigurationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationForm));
            this.StartEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.StartEnabledLabel = new System.Windows.Forms.Label();
            this.UDPPortInput = new System.Windows.Forms.NumericUpDown();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.CrossfadeEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.TransitionTimeInput = new System.Windows.Forms.NumericUpDown();
            this.TransitionTimeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.UDPPortInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransitionTimeInput)).BeginInit();
            this.SuspendLayout();
            // 
            // StartEnabledCheckBox
            // 
            this.StartEnabledCheckBox.AutoSize = true;
            this.StartEnabledCheckBox.Location = new System.Drawing.Point(12, 12);
            this.StartEnabledCheckBox.Name = "StartEnabledCheckBox";
            this.StartEnabledCheckBox.Size = new System.Drawing.Size(136, 21);
            this.StartEnabledCheckBox.TabIndex = 0;
            this.StartEnabledCheckBox.Text = Resources.OPTION_START_ENABLED;
            this.StartEnabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // StartEnabledLabel
            // 
            this.StartEnabledLabel.AutoSize = true;
            this.StartEnabledLabel.Location = new System.Drawing.Point(134, 41);
            this.StartEnabledLabel.Name = "StartEnabledLabel";
            this.StartEnabledLabel.Size = new System.Drawing.Size(67, 17);
            this.StartEnabledLabel.TabIndex = 2;
            this.StartEnabledLabel.Text = Resources.OPTION_UDP_PORT;
            // 
            // UDPPortInput
            // 
            this.UDPPortInput.Location = new System.Drawing.Point(12, 39);
            this.UDPPortInput.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.UDPPortInput.Name = "UDPPortInput";
            this.UDPPortInput.Size = new System.Drawing.Size(116, 22);
            this.UDPPortInput.TabIndex = 3;
            // 
            // SaveButton
            // 
            this.SaveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SaveButton.Location = new System.Drawing.Point(12, 172);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(120, 39);
            this.SaveButton.TabIndex = 5;
            this.SaveButton.Text = Resources.BUTTON_SAVE_CLOSE;
            this.SaveButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(190, 172);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(80, 39);
            this.CancelButton.TabIndex = 6;
            this.CancelButton.Text = Resources.BUTTON_CANCEL;
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // CrossfadeEnabledCheckBox
            // 
            this.CrossfadeEnabledCheckBox.AutoSize = true;
            this.CrossfadeEnabledCheckBox.Location = new System.Drawing.Point(12, 67);
            this.CrossfadeEnabledCheckBox.Name = "CrossfadeEnabledCheckBox";
            this.CrossfadeEnabledCheckBox.Size = new System.Drawing.Size(94, 21);
            this.CrossfadeEnabledCheckBox.TabIndex = 7;
            this.CrossfadeEnabledCheckBox.Text = Resources.OPTION_CROSSFADE;
            this.CrossfadeEnabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // TransitionTimeInput
            // 
            this.TransitionTimeInput.Location = new System.Drawing.Point(12, 94);
            this.TransitionTimeInput.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.TransitionTimeInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TransitionTimeInput.Name = "TransitionTimeInput";
            this.TransitionTimeInput.Size = new System.Drawing.Size(116, 22);
            this.TransitionTimeInput.TabIndex = 9;
            this.TransitionTimeInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // TransitionTimeLabel
            // 
            this.TransitionTimeLabel.AutoSize = true;
            this.TransitionTimeLabel.Location = new System.Drawing.Point(134, 96);
            this.TransitionTimeLabel.Name = "TransitionTimeLabel";
            this.TransitionTimeLabel.Size = new System.Drawing.Size(106, 17);
            this.TransitionTimeLabel.TabIndex = 8;
            this.TransitionTimeLabel.Text = Resources.OPTION_TRANSITION_TIME;
            // 
            // ConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 223);
            this.Controls.Add(this.TransitionTimeInput);
            this.Controls.Add(this.TransitionTimeLabel);
            this.Controls.Add(this.CrossfadeEnabledCheckBox);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.UDPPortInput);
            this.Controls.Add(this.StartEnabledLabel);
            this.Controls.Add(this.StartEnabledCheckBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(300, 270);
            this.MinimumSize = new System.Drawing.Size(300, 270);
            this.Name = "ConfigurationForm";
            this.Text = Resources.WINDOW_CONFIGURATION;
            this.Load += new System.EventHandler(this.ConfigurationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UDPPortInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransitionTimeInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox StartEnabledCheckBox;
        private System.Windows.Forms.Label StartEnabledLabel;
        private System.Windows.Forms.NumericUpDown UDPPortInput;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.CheckBox CrossfadeEnabledCheckBox;
        private System.Windows.Forms.NumericUpDown TransitionTimeInput;
        private System.Windows.Forms.Label TransitionTimeLabel;
    }
}