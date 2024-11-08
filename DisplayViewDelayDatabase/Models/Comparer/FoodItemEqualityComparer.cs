namespace DisplayViewDelayDatabase.Models.Comparer
{
    public class FoodItemEqualityComparer : IEqualityComparer<FoodSelection>
    {
        public bool Equals(FoodSelection x, FoodSelection y)
        {
            if (Object.ReferenceEquals(x, y))
            {
                return true;
            }

            if (x == null || y == null)
            {
                return false;
            }

            return x.FoodItem.Name == y.FoodItem.Name;
        }

        public int GetHashCode(FoodSelection foodSelection)
        {
            int nameHashCode = foodSelection.FoodItem.Name == null ? 0 : foodSelection.FoodItem.Name.GetHashCode();
            //int ageHashCode = person.Age.GetHashCode();

            return nameHashCode; // ^ ageHashCode;
        }
    }
}
