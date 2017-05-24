using Hunter_v2.GameObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_v2.Components.ConversationComponents
{
    class DialogueTree
    {
        List<Quest> quests;
        string dialogue;
        int node, endNode;

        public DialogueTree(string dialogue)
        {
            this.dialogue = dialogue;
            quests = new List<Quest>();
            node = 0;
            endNode = 0;
        }

        public string read(int node)
        {
            string speech;
            string openTag = "<" + node + ">";
            string closeTag = "<" + node + "/>";

            int openTagPos = dialogue.IndexOf(openTag);
            int closeTagPos = dialogue.IndexOf(closeTag);

            speech = dialogue.Substring(openTagPos + openTag.Length, closeTagPos - (openTagPos + openTag.Length));

            return speech;

        }

        public void next()
        {
            node++;
        }

        public void previous()
        {
            node--;
        }

        public Quest giveQuest()
        {
            foreach (Quest q in quests)
            {
                /*
                if (q.id == node)
                {
                    return q;
                }
                */
            }

            return null;
        }
    }
}
