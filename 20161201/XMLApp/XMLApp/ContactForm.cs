using System;
using System.Windows.Forms;

namespace XMLApp
{
  public partial class ContactForm: Form
  {

    #region private variables

    private CContact m_pContact;

    #endregion

    #region .ctors

    /// <summary>
    /// .ctor
    /// </summary>
    public ContactForm()
    {
      InitializeComponent();
    }

    /// <summary>
    /// .ctor
    /// </summary>
    public ContactForm(CContact pContact) :
      this()
    {
      InitializeComponent();
      Text = String.Format("Контакт телефона: {0}",
        String.IsNullOrEmpty(pContact.Title)
        ? "новая запись"
        : pContact.Title);
      m_pContact = pContact;
    }

    #endregion

    #region event handlers

    private void ContactForm_Load(object sender, EventArgs e)
    {
      h_FillForm();
    }


    private void btnOk_Click(object sender, EventArgs e)
    {
      // если не заполнили данными
      if (!h_fillObject()) {
        // временно отменяем назначенный на кнопку DialogResult, 
        // предотвращая закрытие формы
        this.DialogResult = DialogResult.None;
      }
    }

    #endregion

    #region private methods

    /// <summary>
    /// Заполнение формы по объекту
    /// </summary>
    private void h_FillForm()
    {
      edName.Text = m_pContact.Title;
      edPhone.Text = m_pContact.Phone;
      dtBorn.Value = m_pContact.BirthDate;
    }

    /// <summary>
    /// Заполнение объекта по форме
    /// </summary>
    private bool h_fillObject()
    {
      try
      {
        m_pContact.Title = edName.Text;
        labNameError.Visible = false;
      }
      catch (ArgumentException pE)
      {
        labNameError.Text = pE.Message;
        labNameError.Visible = true;
        return false;
      }
      catch (Exception pE)
      {
        MessageBox.Show("Ошибка: " + pE.Message);
        return false;
      }
      m_pContact.Phone = edPhone.Text;
      m_pContact.BirthDate = dtBorn.Value;
      return true;
    }

    #endregion
  }
}
