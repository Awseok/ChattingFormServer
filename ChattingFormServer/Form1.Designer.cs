
namespace udpSocketTest
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.BTN_START = new System.Windows.Forms.Button();
            this.RTB_HISTORY = new System.Windows.Forms.RichTextBox();
            this.TXT_CHAT = new System.Windows.Forms.TextBox();
            this.LST_LOG = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // BTN_START
            // 
            this.BTN_START.Location = new System.Drawing.Point(12, 22);
            this.BTN_START.Name = "BTN_START";
            this.BTN_START.Size = new System.Drawing.Size(74, 24);
            this.BTN_START.TabIndex = 0;
            this.BTN_START.Text = "시작";
            this.BTN_START.UseVisualStyleBackColor = true;
            this.BTN_START.Click += new System.EventHandler(this.BTN_START_Click);
            // 
            // RTB_HISTORY
            // 
            this.RTB_HISTORY.Location = new System.Drawing.Point(12, 52);
            this.RTB_HISTORY.Name = "RTB_HISTORY";
            this.RTB_HISTORY.Size = new System.Drawing.Size(635, 210);
            this.RTB_HISTORY.TabIndex = 1;
            this.RTB_HISTORY.Text = "";
            // 
            // TXT_CHAT
            // 
            this.TXT_CHAT.Location = new System.Drawing.Point(12, 268);
            this.TXT_CHAT.Name = "TXT_CHAT";
            this.TXT_CHAT.Size = new System.Drawing.Size(635, 21);
            this.TXT_CHAT.TabIndex = 2;
            this.TXT_CHAT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TXT_CHAT_KeyDown);
            // 
            // LST_LOG
            // 
            this.LST_LOG.FormattingEnabled = true;
            this.LST_LOG.ItemHeight = 12;
            this.LST_LOG.Location = new System.Drawing.Point(13, 297);
            this.LST_LOG.Name = "LST_LOG";
            this.LST_LOG.Size = new System.Drawing.Size(633, 88);
            this.LST_LOG.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 412);
            this.Controls.Add(this.LST_LOG);
            this.Controls.Add(this.TXT_CHAT);
            this.Controls.Add(this.RTB_HISTORY);
            this.Controls.Add(this.BTN_START);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTN_START;
        private System.Windows.Forms.RichTextBox RTB_HISTORY;
        private System.Windows.Forms.TextBox TXT_CHAT;
        private System.Windows.Forms.ListBox LST_LOG;
    }
}

