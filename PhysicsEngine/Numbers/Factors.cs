﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace PhysicsEngine.Numbers {
	/// <summary>Takes a number in the constructor and builds a list of prime factors.</summary>
	public class Factors {
		/// <summary>
		/// Contains the list of factors stored in two ways - regular list of ints and exponential form.
		/// Helps concatinate lists for multiplication.
		/// </summary>
		public class Container {
			private int lastFactor = int.MinValue;
			private int consecutiveFactorCounter = 0;
			public void Add(int newFactor) {
				InAList.Add(newFactor);
				if(InAList.Count > 0 && InAList.Last() > newFactor)
					throw new Exception("Your list is out of order!");
				if (newFactor == lastFactor || newFactor == 2)
					consecutiveFactorCounter++;
				else {
					consecutiveFactorCounter = 0;
				}
				lastFactor = newFactor;
				
			}
			public void Flush() {
				Count = InAList.Count();
			}
			public int Count;
			public List<BigInteger> InAList = new List<BigInteger>();
			public List<BaseAndPower> AsExponents = new List<BaseAndPower>();

			public string Visualize(){
				string output = string.Empty;
				if (this.InAList.Count > 0)
					output += "(";
				if (this.InAList.Count == 1) {
					output += "Prime number";
				} else {
					for (int i = 0; i < this.InAList.Count(); i++) {
						output += this.InAList[i].ToString();
						if (i != this.InAList.Count() - 1)
							output += " ";
					}
				}
				if(this.InAList.Count > 0)
				output += ")";
				return output;
			}
			//TODO: Use this list to divide numbers and extract the GCF from a multiplication problem
		}

		public BigInteger OrigionalNumber;
		public Container factorsContainer = new Container();
		public Factors(List<int> factors) {
			foreach (int value in factors) {
				Factorize(value);
			}
			this.factorsContainer.InAList.Sort();
		}
		public void Factorize(int factorMe) {
			OrigionalNumber = factorMe;
			for (int i = 2; i < factorMe + 1; i++) {
				if (i > 10000000) {
					i = factorMe;
				}
				while (factorMe % i == 0) {
					factorsContainer.Add(i);
					factorMe /= i;
				}
			}
		}

		public Factors(List<Factors> factors) {
			//TODO: find a good list combing algorithm and make sure this is optimal
			//throw new NotImplementedException();
		}

		internal string Visualize() {
			return factorsContainer.Visualize();
		}
	}
}
