using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BaiTap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu có dòng nào được chọn
            if (listView1.SelectedItems.Count > 0)
            {
                // Lấy dòng đang được chọn
                ListViewItem selectedItem = listView1.SelectedItems[0];

                // Hiển thị dữ liệu dòng lên TextBox
                txtLastname.Text = selectedItem.Text;              // Cột đầu tiên
                txtFirstname.Text = selectedItem.SubItems[1].Text; // Cột thứ hai
                txtPhone.Text = selectedItem.SubItems[2].Text;     // Cột thứ ba
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            //1.Tạo 1 dòng dữ liệu 
            ListViewItem lv = new ListViewItem(txtLastname.Text);
            // thêm dữ liệu vào các cột còn lại 
            lv.SubItems.Add(txtFirstname.Text);
            lv.SubItems.Add(txtPhone.Text);
            // đưa dữ liệu lên listview 
            listView1.Items.Add(lv);  // Thêm dòng mới vào ListView
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFirstname.Text == "" || txtPhone.Text == "" || txtLastname.Text == "")
                {
                    throw new Exception("Vui long nhap day du thong tin sinh vien!");
                }
                if (listView1.SelectedItems.Count > 0) // Giả sử sử dụng DataGridView
                {
                    int selectedRow = listView1.SelectedItems[0].Index; // Lấy chỉ số dòng được chọn
                    listView1.Items.RemoveAt(selectedRow);            
                    MessageBox.Show("Đã xóa thành công!", "Tiêu đề thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                else
                {
                    throw new Exception("Vui lòng chọn một sinh viên để xóa!");
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu có dòng nào được chọn
            if (listView1.SelectedItems.Count > 0)
            {
                // Lấy dòng đang được chọn
                ListViewItem selectedItem = listView1.SelectedItems[0];

                // Cập nhật dữ liệu từ TextBox vào ListView
                selectedItem.Text = txtLastname.Text;              
                selectedItem.SubItems[1].Text = txtFirstname.Text; 
                selectedItem.SubItems[2].Text = txtPhone.Text;    

                MessageBox.Show("Dữ liệu đã được cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không có dòng nào được chọn để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
