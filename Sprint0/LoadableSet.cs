using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Sprint0
{
    /// <summary>
    /// A set that can optionally stage changes that
    /// are only loaded when the Load() method is called.
	/// To make changes immediately, use the Put() and Drop() methods
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
			if (!list.Contains(element))
			{
                list.Add(element);
            }
		}

		public void Drop(T element)
		{
			if (list.Contains(element))
			{
                list.Remove(element);
            }
		}

		public void StagePut(T element)
		{
			stagedUpdates.Add(new StagedUpdate<T>(UpdateType.Put, element));
		}

		public void StageDrop(T element)
		{
            stagedUpdates.Add(new StagedUpdate<T>(UpdateType.Drop, element));
		}

		public void Load()
		{
			// load the updates in the order they were recieved
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

		public bool Exists(Predicate<T> predicate)
		{
			return list.Exists(predicate);
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

