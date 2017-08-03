using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ERP.CommonLayer
{
    public class DataGridViewDisabledTextBoxCell : DataGridViewTextBoxCell
    {
        #region Private Variables

        private bool enabledValue;

        #endregion

        #region Private Properties

        public bool Enabled
        {
            get{return enabledValue;}
            set{enabledValue = value;}
        }

        #endregion

        #region Methods

        // Override the Clone method so that the Enabled property is copied. 
        public override object Clone()
        {
            DataGridViewDisabledTextBoxCell cell =
               (DataGridViewDisabledTextBoxCell)base.Clone();
            cell.Enabled = this.Enabled;
            return cell;
        }

        // By default, enable the textbox cell. 
        public DataGridViewDisabledTextBoxCell()
        {
            this.enabledValue = true;
        }

        protected override void Paint(Graphics graphics,
        Rectangle clipBounds, Rectangle cellBounds, int rowIndex,
        DataGridViewElementStates elementState, object value,
        object formattedValue, string errorText,
        DataGridViewCellStyle cellStyle,
        DataGridViewAdvancedBorderStyle advancedBorderStyle,
        DataGridViewPaintParts paintParts)
        {
            // The button cell is disabled, so paint the border, 
            // background, and disabled button for the cell. 
            if (!this.enabledValue)
            {
                // Draw the cell background, if specified. 
                if ((paintParts & DataGridViewPaintParts.Background) ==
                DataGridViewPaintParts.Background)
                {
                    SolidBrush cellBackground =
                    new SolidBrush(cellStyle.BackColor);
                    graphics.FillRectangle(cellBackground, cellBounds);
                    cellBackground.Dispose();
                }

                // Draw the cell borders, if specified. 
                if ((paintParts & DataGridViewPaintParts.Border) ==
                DataGridViewPaintParts.Border)
                {
                    PaintBorder(graphics, clipBounds, cellBounds,
                    cellStyle,
                    advancedBorderStyle);
                }

                // Calculate the area in which to draw the textbox. 
                Rectangle textBoxArea = cellBounds;
                Rectangle textBoxAdjustment =
                this.BorderWidths(advancedBorderStyle);
                textBoxArea.X += textBoxAdjustment.X;
                textBoxArea.Y += textBoxAdjustment.Y;
                textBoxArea.Height -= textBoxAdjustment.Height;
                textBoxArea.Width -= textBoxAdjustment.Width;

                // Draw the disabled textbox 

                if
                (System.Windows.Forms.VisualStyles.VisualStyleRenderer.IsSupported &&
                Application.RenderWithVisualStyles)
                {
                    if
                    (System.Windows.Forms.VisualStyles.VisualStyleRenderer.IsElementDefined(System.Windows.Forms.VisualStyles.VisualStyleElement.Button.PushButton.Normal))
                    {
                        TextBoxRenderer.DrawTextBox(graphics,
                        textBoxArea, System.Windows.Forms.VisualStyles.TextBoxState.Disabled);

                        // Draw the disabled text. 
                        if (this.FormattedValue is String)
                        {
                            TextRenderer.DrawText(graphics,
                            (string)this.FormattedValue,
                            this.DataGridView.Font,
                            textBoxArea, SystemColors.GrayText);
                        }
                    }
                }
                else
                {
                    Brush brsh = new SolidBrush(Color.Gray);
                    Brush brFill = new SolidBrush(Color.LightGray);
                    Pen p = new Pen(brsh, 1);
                    graphics.DrawRectangle(p, textBoxArea);
                    graphics.FillRectangle(brFill, textBoxArea);
                    graphics.DrawString((string)this.FormattedValue,
                    this.DataGridView.Font, brsh, textBoxArea);
                }
            }
            else
            {
                base.Paint(graphics, clipBounds, cellBounds,
                rowIndex,
                elementState, value, formattedValue, errorText,
                cellStyle, advancedBorderStyle, paintParts);
            }
        }

        #endregion
    }
}
