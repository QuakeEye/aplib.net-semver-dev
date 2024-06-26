using System;

namespace Aplib.Core.Belief
{
    /// <summary>
    /// The <see cref="MemoryBelief{TReference, TObservation}"/> class represents the agent's belief of a single object,
    /// but with additional "memory" of previous observations.
    /// Some <i>object reference</i> is used to generate/update an <i>observation</i> 
    /// (i.e., some piece of information on the game state as perceived by an agent).
    /// This belief also stores a limited amount of previous observations in memory.
    /// </summary>
    /// <remarks>
    /// It implements the <see cref="IBelief"/> interface.
    /// It supports implicit conversion to <typeparamref name="TObservation"/>.
    /// </remarks>
    /// <typeparam name="TReference">The type of the reference used to generate/update the observation.</typeparam>
    /// <typeparam name="TObservation">The type of the observation the belief represents.</typeparam>
    public class MemoryBelief<TReference, TObservation> : Belief<TReference, TObservation>
    {
        /// <summary>
        /// A "memorized" resouce, from the last time the belief was updated.
        /// </summary>
        private readonly CircularArray<TObservation> _memorizedObservations;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemoryBelief{TReference, TObservation}"/> class with an object reference,
        /// and a function to generate/update the observation using the object reference.
        /// Also initializes the memory array with a specified number of slots.
        /// </summary>
        /// <param name="reference">The reference used to generate/update the observation.</param>
        /// <param name="getObservationFromReference">A function that takes a reference and generates/updates a observation.</param>
        /// <param name="framesToRemember">The number of frames to remember back.</param>
        public MemoryBelief(TReference reference, Func<TReference, TObservation> getObservationFromReference, int framesToRemember)
            : base(reference, getObservationFromReference)
        {
            _memorizedObservations = new(framesToRemember);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MemoryBelief{TReference, TObservation}"/> class with an object reference,
        /// a function to generate/update the observation using the object reference,
        /// and a condition on when the observation should be updated.
        /// Also initializes the memory array with a specified number of slots.
        /// </summary>
        /// <param name="reference">The reference used to generate/update the observation.</param>
        /// <param name="getObservationFromReference">A function that takes a reference and generates/updates a observation.</param>
        /// <param name="framesToRemember">The number of frames to remember back.</param>
        /// <param name="shouldUpdate">A function that sets a condition on when the observation should be updated.</param>
        public MemoryBelief(TReference reference, Func<TReference, TObservation> getObservationFromReference, int framesToRemember,
            Func<bool> shouldUpdate)
            : base(reference, getObservationFromReference, shouldUpdate)
        {
            _memorizedObservations = new(framesToRemember);
        }

        /// <summary>
        /// Generates/updates the observation.
        /// Also stores the previous observation in memory.
        /// </summary>
        public override void UpdateBelief()
        {
            // We use the implicit conversion to TObservation to store the observation
            _memorizedObservations.Put(this);
            base.UpdateBelief();
        }

        /// <summary>
        /// Gets the most recently memorized observation.
        /// </summary>
        /// <returns> The most recent memory of the observation.</returns>
        public TObservation GetMostRecentMemory() => _memorizedObservations.GetFirst();

        /// <summary>
        /// Gets the memorized observation at a specific index.
        /// A higher index means a memory further back in time.
        /// If the index is out of bounds, returns the element closest to the index that is in bounds.
        /// </summary>
        /// <returns> The memory of the observation at the specified index.</returns>
        public TObservation GetMemoryAt(int index, bool clamp = false)
        {
            int lastMemoryIndex = _memorizedObservations.Length - 1;
            if (clamp)
                index = Math.Clamp(index, 0, lastMemoryIndex);
            else if (index < 0 || index > lastMemoryIndex)
                throw new ArgumentOutOfRangeException(nameof(index), $"Index must be between 0 and {lastMemoryIndex}.");
            return _memorizedObservations[index];
        }

        /// <summary>
        /// Gets all the memorized observations.
        /// The first element is the newest memory.
        /// </summary>
        /// <returns> An array of all the memorized observations.</returns>
        public TObservation[] GetAllMemories()
        {
            // For now, we return the entire array, but with empty elements for the unused slots
            // TODO: make it return only the used slots
            return _memorizedObservations.ToArray();
        }
    }
}

