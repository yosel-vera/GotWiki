using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace GotWiki.Helpers
{
    public static class Utils
    {

        public static void ExtractSaveResource(string filename, string location)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (var resFilestream = assembly.GetManifestResourceStream(filename))
            {
                if (resFilestream != null)
                {
                    var full = Path.Combine(location, filename);

                    using (var stream = File.Create(full))
                    {
                        resFilestream.CopyTo(stream);
                    }

                }
            }
        }
    }
}
