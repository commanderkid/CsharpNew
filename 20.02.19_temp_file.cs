using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApplication
{
    public class LimitedSizeStack<T>
    {
        StackElement temporaryLink;
        private int ACount = 0;
        private StackElement link = null;
        private class StackElement
        {
            public StackElement Reference;
            public T Element { get; set; }

            public StackElement(StackElement refer, T elem )
            {
                Reference = refer;
                Element = elem;
            }
        }


        public LimitedSizeStack(int limit)
        {
        }

        public void Push(T item)
        {
            if (link == null)
                link = new StackElement(null, item);
            else
            {
                temporaryLink = link;
                link = new StackElement(temporaryLink, item);
            }
            ACount++;
        }

        public T Pop()
        {
            if (link == null)
                throw new NotImplementedException();
            else
            {
                temporaryLink = link;
                link = link.Reference;
                return temporaryLink.Element;
            }
        }

        public int Count
        {
            get
            {
                return ACount;
            }
        }
    }
}
