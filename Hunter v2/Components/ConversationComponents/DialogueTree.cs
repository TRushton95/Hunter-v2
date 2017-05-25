using Hunter_v2.GameObjects;
using Hunter_v2.GameObjects.Quests;
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
        public List<Quest> quests { get; set; }
        public string dialogue { get; set; }
        public int node { get; set; }

        public DialogueTree(string dialogue)
        {
            this.dialogue = dialogue;
            quests = new List<Quest>();
            node = 0;
        }

        //super inefficient
        public string read()
        {
            string speech;
            string openTag = "<" + node + ">";
            string closeTag = "</" + node + ">";

            int openTagPos = dialogue.IndexOf(openTag);
            int closeTagPos = dialogue.IndexOf(closeTag);

            if (openTagPos == -1)
            {
                while (openTagPos == -1)
                {
                    previous();
                    openTag = "<" + node + ">";
                    closeTag = "</" + node + ">";
                    openTagPos = dialogue.IndexOf(openTag);
                    closeTagPos = dialogue.IndexOf(closeTag);
                }
            }

            speech = dialogue.Substring(openTagPos + openTag.Length, closeTagPos - (openTagPos + openTag.Length));

            return speech;

        }

        public void next()
        {
            node++;
        }

        public void previous()
        {
            if (node > 0)
            {
                node--;
            }
        }

        public Quest giveQuest()
        {
            foreach (Quest q in quests)
            {
                if (q.dialogueId == node)
                {
                    return q;
                }
            }

            return null;
        }
    }
}
