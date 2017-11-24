using Langlab.Core.Business;
using System.Collections.Generic;

namespace Langlab.Core.Business
{
    public class Word//Concept
    {
        public string Text { get; set; }
        public string Language { get; set; }
        public List<WordFacet> Facets { get; set; } = new List<WordFacet>();
    }

    public class WordFacet//Facet
    {
        public string Id { get; set; }
        public string Pronunciation { get; set; }
        public string Meaning { get; set; }
        public string Translation { get; set; }
        public string Language { get; set; }
        public List<WordFacetExample> Examples { get; set; } = new List<WordFacetExample>();
        public PartOfSpeech POS { get; set; }
    }
    public class WordFacetExample//Facet
    {
        public string Sentence { get; set; }
        public string Translation { get; set; }
        public string Language { get; set; }
    }

    
}
