public static class GetPathFile
{
    public static string ReturnPathFile()
    {
        string pathfile = "";
        
        string pathfileJiajun = "C:\\Users\\JiaJun\\Documents\\GitHub\\Project-B\\Main\\Airline\\DataSources";
        string pathfileJiajunLaptop = "C:\\Users\\JiaJun Li\\Documents\\GitHub\\Project-B\\Main\\Airline\\DataSources";
        string patfileMarissa = "C:\\Users\\mbraa\\Development_Y1\\projectB\\_project_B Airline\\Project-B\\Main\\Airline\\DataSources";
        string pathfileSoufiane = "C:\\Users\\soufi\\OneDrive\\Git\\Project B\\Project-B\\Main\\Airline\\DataSources";
        string pathfileMarieClaire = "C:\\Users\\marie\\OneDrive - Hogeschool Rotterdam\\Semester 2\\Project B\\Project-B\\Main\\Airline\\DataSources";
        string pathfileMaria = "C:\\Users\\iimma\\source\\repos\\GitHub\\Project-B\\Main\\Airline\\DataSources";

        if (Directory.Exists(pathfileJiajun))
        {
            pathfile = pathfileJiajun;
        }

        else if (Directory.Exists(pathfileJiajunLaptop))
        {
            pathfile = pathfileJiajunLaptop;
        }

        else if (Directory.Exists(patfileMarissa))
        {
            pathfile = patfileMarissa;
        }

        else if (Directory.Exists(pathfileSoufiane))
        {
            pathfile = pathfileSoufiane;
        }

        else if (Directory.Exists(pathfileMarieClaire))
        {
            pathfile = pathfileMarieClaire;
        }

        else if (Directory.Exists(pathfileMaria))
        {
            pathfile = pathfileMaria;
        }

        return pathfile;
    }
}