namespace JsonData {
    public class Artist {
        public string ArtistName { get; set; }
        public string RealName { get; set; }
        public int Age { get; set; }
        public string Hometown { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
      
      
        public override string ToString()
        {
            return $@"
            ArtistName: {ArtistName}
            RealName: {RealName}
            Age: {Age}
            Hometown: {Hometown}
            GroupId: {GroupId}
            Group: {Group}";
        }
    }

}