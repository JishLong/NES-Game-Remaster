using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Sprint0
{
    /// <summary>
    /// A set that can optionally stage changes that
    /// are only loaded when the Load() method is called.
	/// To make changes immediately, use the Put() and Drop() methods.
	/// 
    /// Rules:
    ///		Cannot stage multiple Updates targeting the same element.
    ///		Cannot call Put()  tergeting elements already in set.
    ///		Cannot call Drop() tergeting elements not in set.
	///
	/// This is useful for delaying actions such as asynchronous user input
	/// from the web server.  By delaying button releases by 1 frame, you ensure
	/// that each button press is processed during an Update() methdod. (assuming proper implementation)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LoadableSet<T> : IEnumerable<T>
	{
		private readonly List<T> list;
		private readonly List<StagedUpdate<T>> stagedUpdates;

		public LoadableSet()
		{
			list = new List<T>();
			stagedUpdates = new List<StagedUpdate<T>>();
		}

		public void Put(T element)
		{
			if (list.Contains(element))
			{
				throw new Exception($"Set already contains {element.ToString()}");
			}
			list.Add(element);
		}

		public void Drop(T element)
		{
			if (!list.Contains(element))
			{
				throw new Exception($"Set does not contain {element.ToString()}");
			}
            list.Remove(element);
		}

		public void StagePut(T element)
		{
			this.VerifyElementNotStaged(element);
			stagedUpdates.Add(new StagedUpdate<T>(UpdateType.Put, element));
		}

		public void StageDrop(T element)
		{
            this.VerifyElementNotStaged(element);
            stagedUpdates.Add(new StagedUpdate<T>(UpdateType.Drop, element));
		}

		public void Load()
		{
			foreach (var update in stagedUpdates)
			{
				if (update.updateType == UpdateType.Put)
				{
					this.Put(update.element);
				}
				else
				{
					this.Drop(update.element);
				}
			}
			stagedUpdates.Clear();
		}

		public bool Contains(T element)
		{
			return list.Contains(element);
		}

		public bool ElementStaged(T element)
		{
			return stagedUpdates.Exists(e => e.Equals(element));
		}

		public List<StagedUpdate<T>> GetStagedUpdates()
		{
			return stagedUpdates;
		}

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)list).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)list).GetEnumerator();
        }

        // used internally to manage staging/loading
        private void VerifyElementNotStaged(T element)
		{
            if (stagedUpdates.Exists(e => e.element.Equals(element)))
            {
                 throw new Exception($"Cannot stage multiple updates targeting {element.ToString()}");
            }
        }
	}

    public enum UpdateType
    {
        Put,
        Drop
    }

    public class StagedUpdate<T>
    {
        public UpdateType updateType { get; }
        public T element { get; }

        public StagedUpdate(UpdateType updateType, T element)
        {
            this.updateType = updateType;
            this.element = element;
        }
    }
}

