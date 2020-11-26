using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;
using LB_7B_WF.ContactsServiceReference;
using LB_7B_WF.WCFContactsServiceReference;
using PhoneContact = LB_7B_WF.ContactsServiceReference.PhoneContact;

namespace LB_7B_WF
{
    public partial class Form1 : Form
    {
        private readonly ContactsServiceSoapClient _client;
        private readonly PhoneContactServiceClient _wcfClient;

        private List<PhoneContact> _phoneContacts;
        private PhoneContact _selectedPhoneContact;

        private List<WCFContactsServiceReference.PhoneContact> _phoneContactsWcf;
        private WCFContactsServiceReference.PhoneContact _selectedPhoneContactWcf;

        private readonly bool _useWcf;

        public Form1()
        {
            InitializeComponent();
            listView1.Width = 300;

            _client = new ContactsServiceSoapClient();
            _wcfClient = new PhoneContactServiceClient("NetTcpBinding_IPhoneContactService");

            _useWcf = bool.Parse(ConfigurationManager.AppSettings.Get("useWCF"));
        }

        //Events
        private void Form1_Load(object sender, EventArgs e)
        {
            if (_useWcf)
            {
                var phoneContacts = _wcfClient.GetPhoneContacts();
                _phoneContactsWcf = phoneContacts.ToList();

                RenderPhoneContacts(_phoneContactsWcf.Select(MapToMainModel));
            }
            else
            {
                var phoneContacts = _client.GetPhoneContacts();
                _phoneContacts = phoneContacts.ToList();

                RenderPhoneContacts(phoneContacts);
            }
        }

        private void AddButtonClick(object sender, EventArgs e)
        {
            if (!_useWcf)
            {
                var phoneContact = new PhoneContact
                {
                    Name = nameTextBox.Text,
                    Phone = phoneTextBox.Text,
                };

                var updatedPhoneContacts = _client.AddContact(phoneContact);
                _phoneContacts = updatedPhoneContacts.ToList();

                RenderPhoneContacts(updatedPhoneContacts);
            }
            else
            {
                var phoneContactWcf = new WCFContactsServiceReference.PhoneContact
                {
                    Name = nameTextBox.Text,
                    Phone = phoneTextBox.Text,
                };

                var updatedPhoneContactsWcf = _wcfClient.AddPhoneContact(phoneContactWcf);
                _phoneContactsWcf = updatedPhoneContactsWcf.ToList();

                RenderPhoneContacts(updatedPhoneContactsWcf.Select(MapToMainModel));
            }
            nameTextBox.Text = "";
            phoneTextBox.Text = "";
        }

        private void UpdateButtonClick(object sender, EventArgs e)
        {
            if (!_useWcf)
            {
                _selectedPhoneContact.Name = nameTextBox.Text;
                _selectedPhoneContact.Phone = phoneTextBox.Text;

                var updatedPhoneContacts = _client.UpdateContact(_selectedPhoneContact);
                _phoneContacts = updatedPhoneContacts.ToList();

                RenderPhoneContacts(updatedPhoneContacts);
            }
            else
            {
                _selectedPhoneContactWcf.Name = nameTextBox.Text;
                _selectedPhoneContactWcf.Phone = phoneTextBox.Text;

                var updatedPhoneContactsWcf = _wcfClient.UpdatePhoneContact(_selectedPhoneContactWcf);
                _phoneContactsWcf = updatedPhoneContactsWcf.ToList();

                RenderPhoneContacts(updatedPhoneContactsWcf.Select(MapToMainModel));
            }
            nameTextBox.Text = "";
            phoneTextBox.Text = "";
        }

        private void ListViewSelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_useWcf)
            {
                var selectedContact = _phoneContacts[listView1.FocusedItem.Index];
                _selectedPhoneContact = selectedContact;

                nameTextBox.Text = selectedContact.Name;
                phoneTextBox.Text = selectedContact.Phone;
            }
            else
            {
                var selectedContactWcf = _phoneContactsWcf[listView1.FocusedItem.Index];
                _selectedPhoneContactWcf = selectedContactWcf;

                nameTextBox.Text = selectedContactWcf.Name;
                phoneTextBox.Text = selectedContactWcf.Phone;
            }
        }

        private void RemoveButtonClick(object sender, EventArgs e)
        {

            if (!_useWcf)
            {
                var updatedPhoneContacts = _client.RemoveContact(_selectedPhoneContact.Id);
                _phoneContacts = updatedPhoneContacts.ToList();

                RenderPhoneContacts(updatedPhoneContacts);
            }
            else
            {
                var updatedPhoneContactsWcf = _wcfClient.RemovePhoneContact(_selectedPhoneContactWcf.Id);
                _phoneContactsWcf = updatedPhoneContactsWcf.ToList();

                RenderPhoneContacts(updatedPhoneContactsWcf.Select(MapToMainModel));
            }
            nameTextBox.Text = "";
            phoneTextBox.Text = "";
        }


        //General methods
        private void RenderPhoneContacts(IEnumerable<PhoneContact> phoneContacts)
        {
            listView1.Clear();
            foreach (var phoneContact in phoneContacts)
            {
                listView1.Items.Add($"{phoneContact.Name} {phoneContact.Phone}");
            }
        }

        private PhoneContact MapToMainModel(WCFContactsServiceReference.PhoneContact phoneContact) => new PhoneContact
        {
            Id = phoneContact.Id,
            Name = phoneContact.Name,
            Phone = phoneContact.Phone
        };
    }
}
