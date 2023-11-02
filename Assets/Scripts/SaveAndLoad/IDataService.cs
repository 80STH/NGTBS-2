using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public interface IDataService
    {
        bool SaveData<T>(string RelativePath, T Data, bool Encrypted);

        T LoadData<T>(string RelativePath, bool Encrypted);
    }
