
import Data.List (sortBy, sort)
import Data.Function (on)

data Person = Person { 
                name :: String, 
                age :: Int } 
                deriving (Show, Eq)

instance Ord Person where
   compare p q  
    | ageCompare == EQ = compare (name p) (name q)
    | otherwise = ageCompare
    where ageCompare = compare (age q) (age p)

main = do
  let numbers = [645.32, 37.40, 76.30, 5.40, -34.23, 1.11, -34.94, 23.37, 635.46, -876.22, 467.73, 62.26]
  putStr "\nSorted Numbers by numerical value\n" 
  -- sort :: Ord a => [a] -> [a]
  print (sort numbers)

  putStr "\nSorted people alphabetically (lexicographically) by name\n"
  let people = [Person "Hal" 20, Person "Susann" 31, Person "Dwight" 19, Person "Kassandra" 21, Person "Lawrence" 25, Person "Cindy" 22, Person "Cory" 27, Person "Mac" 19, Person "Romana" 27,Person "Doretha" 32, Person "Danna" 20, Person "Zara" 23, Person "Rosalyn" 26, Person "Risa" 24,Person "Benny" 28, Person "Juan" 33, Person "Natalie" 25 ]
  -- Semi group, Monoid
    -- sortBy :: (a -> a -> Ordering) -> [a] -> [a]
  let sorted_people = sortBy (compare `on` name) people
  print(sorted_people)
  putStr "\n"
  putStr "\nSort people by age(descending) & lexicographical by name for same age\n"
  let sorted_people = sort people
  print(sorted_people)