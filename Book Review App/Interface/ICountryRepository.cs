﻿using Book_Review_App.Models;

namespace Book_Review_App.Interface
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountry(int countryId);
        Country GetCountryByLibrary(int LibraryId);
        ICollection<Library> GetLibraryFromACountry(int countryId);
        bool CountryExists(int id);


    }
}