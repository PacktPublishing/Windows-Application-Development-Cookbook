/*
    Exemplary file for Chapter 4 - Data Storage.
    Recipe: Reading an XML file.
*/

using CH04.Models;
using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml;
using System.Xml.Linq;
using Windows.Storage;

namespace CH04.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<EventViewModel> Events { get; set; }
        public DateTimeOffset Date { get; set; } = DateTimeOffset.Now;
        public string Description { get; set; }
        public ICommand CmdAdd { get; set; }
        public ICommand CmdSave { get; set; }
        public ICommand CmdLoad { get; set; }

        public MainViewModel()
        {
            Events = new ObservableCollection<EventViewModel>();
            CmdAdd = new RelayCommand(() => AddEvent());
            CmdSave = new RelayCommand(async () => await Save());
            CmdLoad = new RelayCommand(async () => await Load());
        }

        private void AddEvent()
        {
            EventViewModel e = new EventViewModel()
            {
                Date = Date.Date,
                Description = Description
            };
            Events.Add(e);
        }

        private async Task Save()
        {
            StringBuilder builder = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            using (XmlWriter writer = XmlWriter.Create(builder, settings))
            {
                XDocument doc = new XDocument();
                XElement rootElement = new XElement("events");
                doc.Add(rootElement);
                foreach (EventViewModel e in Events)
                {
                    XElement eventElement = new XElement("event",
                        new XElement("date", e.Date.ToString("yyyy-MM-dd")),
                        new XElement("description", e.Description));
                    rootElement.Add(eventElement);
                }
                doc.Save(writer);
            }

            StorageFolder folder = ApplicationData.Current.LocalFolder;
            StorageFile file = await folder.CreateFileAsync("Events.xml", CreationCollisionOption.OpenIfExists);
            await FileIO.WriteTextAsync(file, builder.ToString());
        }

        private async Task Load()
        {
            StorageFolder folder = ApplicationData.Current.LocalFolder;
            StorageFile file = (StorageFile)await folder.TryGetItemAsync("Events.xml");
			if (file == null)
			{
				return;
			}
			
            string xml = await FileIO.ReadTextAsync(file);

            Events.Clear();
            XDocument doc = XDocument.Parse(xml);
            foreach (XElement eventElement in doc.Descendants("event"))
            {
                string dateString = eventElement.Element("date").Value;
                string description = eventElement.Element("description").Value;
                DateTime date;
                if (DateTime.TryParse(dateString, out date))
                {
                    EventViewModel e = new EventViewModel()
                    {
                        Date = date,
                        Description = description
                    };
                    Events.Add(e);
                }
            }
        }
    }
}
