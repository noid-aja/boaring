using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1.Controllers
{
    interface Isearch<T>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    
    {
        T? Cari(int id);
        List<T> CariNama(string nama);
    }
}
