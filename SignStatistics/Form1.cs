using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace SignStatistics
{
    public partial class Form1 : Form
    {
        private String signTableFileName;
        private String allMemberTableFileName;

        public Form1()
        {
            InitializeComponent();
        }

        private void signTableButton_Click(object sender, EventArgs e)
        {
            this.signTableFileName = this.showExcelFileDialog();
            this.signTableFileNameTxb.Text = this.signTableFileName;
        }

        private void allMemberTableButton_Click(object sender, EventArgs e)
        {
            this.allMemberTableFileName = this.showExcelFileDialog();
            this.allMemberTableFileNameTxb.Text = this.allMemberTableFileName;
        }

        private String showExcelFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "请选择文件";
            openFileDialog.Filter = "所有文件(*xls*)|*.xls*"; //设置要选择的文件的类型
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog.FileName;
            }
            return null;
        }

        // 修改进度条值
        private delegate void setProgressBarValue_dg(int value);
        private void setProgressBarValue(int value)
        {
            this.progressBar1.Value = value;
        }

        private delegate void setExportButtonEnable_dg(bool value);
        private void setExportButtonEnable(bool enable)
        {
            this.exportButton.Enabled = enable;
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            if (this.signTableFileName == null)
            {
                MessageBox.Show("请先上传签到表！");
                return;
            }
            else if (this.allMemberTableFileName == null)
            {
                MessageBox.Show("请先上传全部成员表！");
                return;
            }

            if (this.signTableFileName == this.allMemberTableFileName)
            {
                MessageBox.Show("两份表格相同，请确认后重试！");
                return;
            }
            Task task = Task.Run(() =>
            {
                // 禁用按钮
                this.Invoke(new setExportButtonEnable_dg(setExportButtonEnable), false);
                // 还原进度条
                this.Invoke(new setProgressBarValue_dg(setProgressBarValue), 0);

                Excel.Application excel = new Excel.Application();
                Excel.Workbook signTableBook = excel.Workbooks.Open(signTableFileName);
                Excel.Workbook allMemberTableBook = excel.Workbooks.Open(allMemberTableFileName);
                Excel.Worksheet signTableSheet = (Excel.Worksheet)signTableBook.Worksheets[1];
                Excel.Worksheet allMemberTableSheet = (Excel.Worksheet)allMemberTableBook.Worksheets[1];

                signTableSheet.Cells[1, 2].Value2 = "单位";
                int signTableIndex = 2;

                //Dictionary<string, List<String>> signUserDic = new Dictionary<string, List<String>>();
                //while (signTableSheet.Cells[signTableIndex, 1].Value2 != null)
                //{
                //    String name = signTableSheet.Cells[signTableIndex, 1].Value2.ToString();
                //    List<String> signUserDepartmentList = new List<string>();
                //    int allMemberTableIndex = 2;
                //    int setIndex = 2;// 部门的字段位置
                //    while (allMemberTableSheet.Cells[allMemberTableIndex, 1].Value2 != null)
                //    {
                //        if (allMemberTableSheet.Cells[allMemberTableIndex, 1].Value2.ToString() == name)
                //        {
                //            //signTableSheet.Cells[signTableIndex, setIndex].Value2 = allMemberTableSheet.Cells[allMemberTableIndex, 2].Value2;
                //            signUserDepartmentList.Add(allMemberTableSheet.Cells[allMemberTableIndex, 2].Value2);
                //            setIndex++;
                //        }
                //        allMemberTableIndex++;
                //    }
                //    signUserDic.Add(name, signUserDepartmentList);
                //    //设置进度条的值
                //    this.Invoke(new setProgressBarValue_dg(setProgressBarValue), (int)(signTableIndex * 100 / signTableSheet.UsedRange.Rows.Count));
                //    signTableIndex++;
                //}
                //var sortedDict = signUserDic.OrderBy(x => x.Value[0]).ToDictionary(x => x.Key, x => x.Value);

                Dictionary<string, List<String>> departmentDic = new Dictionary<string, List<String>>();
                List<String> repetitionNameList = new List<string>();
                departmentDic.Add("无对应部门", new List<string>());
                while (signTableSheet.Cells[signTableIndex, 1].Value2 != null)
                {
                    String name = signTableSheet.Cells[signTableIndex, 1].Value2.ToString();
                    int allMemberTableIndex = 2;
                    List<String> departmentList = new List<string>();
                    while (allMemberTableSheet.Cells[allMemberTableIndex, 1].Value2 != null)
                    {
                        if (allMemberTableSheet.Cells[allMemberTableIndex, 1].Value2.ToString() == name)
                        {
                            String department = allMemberTableSheet.Cells[allMemberTableIndex, 2].Value2;
                            if (departmentDic.ContainsKey(department) && !departmentDic[department].Contains(name))
                            {
                                departmentDic[department].Add(name);
                            }
                            else
                            {
                                List<String> nameList = new List<String>();
                                nameList.Add(name);
                                departmentDic.Add(department, nameList);
                            }
                            departmentList.Add(department);
                        }
                        allMemberTableIndex++;
                    }
                    if (departmentList.Count == 0)
                    {
                        departmentDic["无对应部门"].Add(name);
                    }
                    else if (departmentList.Count > 1)
                    {
                        repetitionNameList.Add(name);
                    }

                    //设置进度条的值
                    this.Invoke(new setProgressBarValue_dg(setProgressBarValue), (int)(signTableIndex * 100 / signTableSheet.UsedRange.Rows.Count));
                    signTableIndex++;
                }
                signTableBook.Close(true);
                allMemberTableBook.Close(true);

                Excel.Workbook exportWorkbook = excel.Workbooks.Add(Type.Missing);
                Excel.Worksheet exportWorksheet = exportWorkbook.Worksheets.Add(Type.Missing);
                exportWorksheet.Cells[1, 1].Value2 = "部门";
                exportWorksheet.Cells[1, 2].Value2 = "姓名";
                exportWorksheet.Cells[1, 3].Value2 = "人数";

                int departmentCellIndex = 2;
                foreach (var item in departmentDic)
                {
                    if (item.Value.Count > 0)
                    {
                        // 合并部门单元格
                        Excel.Range departmentRange = exportWorksheet.Cells.Range[exportWorksheet.Cells[departmentCellIndex, 1], exportWorksheet.Cells[departmentCellIndex + item.Value.Count - 1, 1]];
                        departmentRange.Value2 = Type.Missing;
                        departmentRange.Merge(Type.Missing);
                        departmentRange.Value2 = item.Key;

                        // 合并人数单元格
                        Excel.Range countRange = exportWorksheet.Cells.Range[exportWorksheet.Cells[departmentCellIndex, 3], exportWorksheet.Cells[departmentCellIndex + item.Value.Count - 1, 3]];
                        countRange.Value2 = Type.Missing;
                        countRange.Merge(Type.Missing);
                        countRange.Value2 = item.Value.Count;

                        // 填入姓名
                        foreach (String name in item.Value)
                        {
                            exportWorksheet.Cells.Cells[departmentCellIndex, 2].Value2 = name;
                            if (repetitionNameList.Contains(name))
                            {
                                exportWorksheet.Range[exportWorksheet.Cells[departmentCellIndex, 2], exportWorksheet.Cells[departmentCellIndex, 3]].Interior.ColorIndex = 3;
                            }
                            departmentCellIndex++;
                        }
                    }
                }

                exportWorkbook.Close(true);

                excel.Quit();
                // 安全回收进程
                System.GC.GetGeneration(excel);

                // 导出完成
                this.Invoke(new setProgressBarValue_dg(setProgressBarValue), 100);
                this.Invoke(new setExportButtonEnable_dg(setExportButtonEnable), true);
                MessageBox.Show("导出成功！");
            });
        }
    }
}
