using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenuim_Web_Drive_Task.Factory
{
    public interface Home
    {
        void GoToPage();
        void Signup();
        void IsSignupSuccessful();
        void IsTitleExists();
        void Title();
    }
}
