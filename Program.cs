using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = MusicStore.GetData().AllArtists;
            List<Group> Groups = MusicStore.GetData().AllGroups;

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            Artist MtVernonArtist = Artists.FirstOrDefault(artist => artist.Hometown == "Mount Vernon");
            Console.WriteLine(MtVernonArtist.ArtistName);
            Console.WriteLine(MtVernonArtist.Age);
            // Name: DMX
            // Age: 46

            //Who is the youngest artist in our collection of artists?
            Artist YoungestArtist = Artists.FirstOrDefault(art => art.Age == Artists.Min(artist => artist.Age));
            Console.WriteLine(YoungestArtist.ArtistName);
            Console.WriteLine(YoungestArtist.Age);
            // Youngest artist: Chance the Rapper, 23

            //Display all artists with 'William' somewhere in their real name
            List<Artist> AllWilliams = Artists.Where(artist => artist.RealName.Contains("William")).ToList();
            PrintEach(AllWilliams);

            //Display the 3 oldest artist from Atlanta
            List<Artist> OldestArtistsFrAtlanta = Artists.Where(artist => artist.Hometown == "Atlanta").OrderByDescending(artist => artist.Age).Take(3).ToList();
            PrintEach(OldestArtistsFrAtlanta);
            // 3 oldest artists from Atlanta: Ludacris (39), Andre 3000 (41), Lil Jon (45)

            //(Optional) Display the Group Name of all groups that have members that are not from New York City
            List<Group> GroupsNotNYC = Groups.Where(group => group.Members.Select(member => member.Hometown != "New York City")).ToList();
            PrintEach(GroupsNotNYC);

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
            List<Artist> WuTangClan = Groups.Where(group => group.GroupName == "Wu-Tang Clan").Select(group => group.Members.Select(member => member.ArtistName)).ToList();
            PrintEach(WuTangClan);

        }
        public static void PrintEach(IEnumerable<dynamic> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
