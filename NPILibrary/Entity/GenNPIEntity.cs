using System;
using System.Collections.Generic;
using System.Text;

namespace AsusLibrary.Entity
{
    public class GenNPIEntity:BaseEntity
    {
        private GenMainEntity _Main;
        private List<GenFormEntity> _FormList;
        private SortedList<string,GenPNEntity> _GenPNList;


        public GenMainEntity Main
        {
            set { _Main = value; }
            get { return _Main; }
        }

        public List<GenFormEntity> FormList
        {
            set { _FormList = value; }
            get { return _FormList; }
        }

        public SortedList<string, GenPNEntity> GenPNList
        {
            set { _GenPNList = value; }
            get { return _GenPNList; }
        }
    }
}
