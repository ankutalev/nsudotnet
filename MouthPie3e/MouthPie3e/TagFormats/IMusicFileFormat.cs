using MouthPie3e.Enums;

namespace MouthPie3e.TagFormats
{
    public interface IMusicFileFormat
    {
        public string FormatName { get; }
        public void UseFile(string fileName);
        
        public void WriteFile(string file);
        public void WriteFile();
        


        public TagWriteStatus SetTitle(string title, string fileName);
        public TagWriteStatus SetTitle(string title);

        public TagWriteStatus SetArtist(string artist, string fileName);
        public TagWriteStatus SetArtist(string artist);

        public TagWriteStatus SetAlbum(string title, string fileName);
        public TagWriteStatus SetAlbum(string album);

    }
}