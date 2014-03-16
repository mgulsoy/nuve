﻿using System;
using Nuve.Morphologic.Structure;
using QuickGraph;

namespace Nuve.Morphologic
{
    class Morphotactics
    {
        private readonly ArrayAdjacencyGraph<string, Transition<string>> graph;

        public Morphotactics(ArrayAdjacencyGraph<string, Transition<string>> graph)
        {
            this.graph = graph;
        }

        public bool HasTransition(string previousMorphemeId, string nextMorphemeId)
        {
            return graph.ContainsEdge(previousMorphemeId, nextMorphemeId);
        }

        public bool IsValid(Word word)
        {

            for (int i = 0; i < word.AllomorphCount - 1; i++)
            {
                Transition<string> transition;
                bool edgeExists = graph.TryGetEdge(word[i].Morpheme.Id, word[i+1].Morpheme.Id, out transition);
                if (edgeExists && !transition.Conditions.IsTrue(word[i]))
                {
                    return false;
                }
            }

            return true;

        }


        public bool IsConditionTrue(Allomorph previous, Allomorph next)
        {
            throw new NotImplementedException();
        }
    }
}
