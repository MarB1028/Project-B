﻿public class Destination
{
    public string DisplayNo;
    public string Country;
    public string City;
    public string Abbreviation;
    public string Airport;
    public int Distancekm;
    public int FlightDuration;
    public string Status;

    public Destination(string displayNo, string country, string city, string abbreviation, string airport, int distancekm, int flightDuration, string status)
    {
        DisplayNo = displayNo;
        Country = country;
        City = city;
        Abbreviation = abbreviation;
        Airport = airport;
        Distancekm = distancekm;
        FlightDuration = flightDuration;
        Status = status;
    }
}