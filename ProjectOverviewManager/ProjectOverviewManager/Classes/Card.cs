using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOverviewManager
{
    class Card
    {
        private String title;
        private String description;
        private String date;

        public Card(String title, String description, String date)
        {
            this.title = title;
            this.description = description;
            this.date = date;
        }
    }
}