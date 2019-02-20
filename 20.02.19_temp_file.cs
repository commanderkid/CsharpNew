using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TodoApplication
{
    public class LimitedSizeStack<T>
    {
        StackElement LinqToLastElement;

        StackElement temporaryLink;
        private int ACount = 0;
        private StackElement link = null;
        private int Limit;
        private class StackElement
        {
            public StackElement Reference;
            public T Element { get; set; }
            public StackElement LinqToMyself;
            public StackElement(StackElement refer, StackElement linqToFutyre, T elem)
            {
                LinqToMyself = linqToFutyre;
                Reference = refer;
                Element = elem;
            }
        }

        public LimitedSizeStack(int limit)
        {
            if (limit <= 0)
                throw new Exception();
            Limit = limit;

        }

        public void Push(T item)
        {

            if (link == null)
            {
                link = new StackElement(null, null, item);
                LinqToLastElement = link;
                ++ACount;
            }
            else if(ACount < Limit)
            {
                temporaryLink = link;
                link = new StackElement(temporaryLink, null, item);
                temporaryLink.LinqToMyself = link;
                ++ACount;
            }
            else
            {
                temporaryLink = link;
                link = new StackElement(temporaryLink, null, item);
                temporaryLink.LinqToMyself = link;
                LinqToLastElement = LinqToLastElement.LinqToMyself;
                LinqToLastElement.Reference = null;
            }
        }

        public T Pop()
        {
            if (link == null)
                throw new NotImplementedException();
            else
            {
                temporaryLink = link;
                link = link.Reference;
                --ACount;
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
