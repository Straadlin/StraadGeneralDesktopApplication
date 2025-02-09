﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using General_Desktop_Application.Classes;
using General_Desktop_Application.DataLayer;
using General_Desktop_Application.EF;

namespace General_Desktop_Application.BusinessLayer
{
    class BState
    {
        public static state FindByUUID(Guid objUUID)
        {
            try
            {
                using (ModelContext objContext = new ModelContext())
                {
                    return objContext.states.Where(s => s.stat_uuid__uniqueidentifier == objUUID).FirstOrDefault();
                }
            }
            catch { }

            return null;
        }

        public static state FindByName(string stName, country objCountry)
        {
            try
            {
                using (ModelContext objContext = new ModelContext())
                {
                    return objContext.states.Where(s => s.stat_name__nvarchar == stName && s.coun_uuid__uniqueidentifier == objCountry.coun_uuid__uniqueidentifier).FirstOrDefault();
                }
            }
            catch { }

            return null;
        }

        public static List<state> GetMexicosStates()
        {
            try
            {
                using (ModelContext objContext = new ModelContext())
                {
                    return (from country in objContext.countries
                            join state in objContext.states on country.coun_uuid__uniqueidentifier equals state.coun_uuid__uniqueidentifier
                            where (country.coun_code__nvarchar == "MX")
                            select state).ToList();
                }
            }
            catch { }

            return null;
        }
    }
}