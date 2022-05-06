using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempElementsLib
{
    public class TempElementsList : ITempElements
    {
        private readonly List<ITempElement> elements;
        public bool IsEmpty => elements.Count == 0;

        public IReadOnlyCollection<ITempElement> Elements => elements;

        public TempElementsList()
        {
            elements = new List<ITempElement>();
        }
        
        public void AddElement<T>() where T : new()
        {
            //elements.Add( );
        }

        public void Dispose()
        {
            
        }

        public void RemoveDestroyed()
        {
            foreach(var item in elements)
            {

            }
        }
        public void MoveElementTo<T>(T element, string newPath)
        {

        }
        ~TempElementsList()
        {
            Dispose();
        }
        public void DeleteElement<T>(T element)
        {
            if (element is TempDir tempDir)
            {
                DirectoryInfo directoryInfo = new DirectoryInfo (tempDir.DirPath);
                if(directoryInfo.Exists)
                    directoryInfo.Delete(true);
            }
            if (element is TempFile tempFile)
            {
                FileInfo fileInfo = new FileInfo(tempFile.FilePath);
                if (fileInfo.Exists)
                    fileInfo.Delete();
            }
        }

    }
}
