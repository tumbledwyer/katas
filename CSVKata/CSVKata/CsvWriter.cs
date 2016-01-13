using System;
using System.Collections.Generic;

namespace CSVKata
{
    public interface ICsvWriter
    {
        void Save(string fileName, string liner);
    }

    public class CsvWriter : ICsvWriter
    {
        private readonly IFolder _folder;

        public CsvWriter(IFolder folder)
        {
            if (folder == null) throw new ArgumentNullException(nameof(folder));
            _folder = folder;
        }

        public virtual void Save(string fileName, string line)
        {
            _folder.AppendLine(fileName,line);
        }
    }
    
}