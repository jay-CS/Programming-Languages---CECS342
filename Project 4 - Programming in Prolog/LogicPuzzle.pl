% Days when objects were sighted
day(1). % Tuesday
day(2). % Wednesday
day(3). % Thursday
day(4). % Friday

% Actual objects
object(balloon).
object(clothesline).
object(frisbee).
object(watertower).

solve :-
    % Four reported sighting on different day
    day(BarradaDay), day(GortDay), day(KlatuDay), day(NiktoDay),
    all_different([BarradaDay, GortDay, KlatuDay, NiktoDay]),
    
    % Each person gets different explanation of actual objects seen
    object(BarradaObj), object(GortObj), object(KlatuObj), object(NiktoObj),
    all_different([BarradaObj, GortObj, KlatuObj,NiktoObj]),
    
    % Person name, Object, Day number
    Triples = [[barrada, BarradaObj, BarradaDay],
                [gort, GortObj, GortDay],
                [klatu, KlatuObj, KlatuDay],
                [nikto, NiktoObj, NiktoDay]],
    
    % ? member([_, balloon, BalloonDay], [["B", balloon, 1], ["C", watertower, 3]]).
    
    % 1. Klatu made sighting earlier in week than one who saw ballon,
    %  but later in week than one who spotted frisbee(who isnt Ms.Gort)
    member([_, balloon, BallonDay], Triples),
    earlier(KlatuDay, BallonDay), % Klatu see earlier than balloon guy
    member([_, frisbee, FrisbeeDay], Triples),
    earlier(FrisbeeDay, KlatuDay), % Frisbee guy see earlier than Klatu
    \+ member([gort, frisbee, _], Triples), % Gort didn't spot frisbee
    
    % 2. Friday's sighting was made by either Ms.Barrada or the one who saw a clothesline(or both)
    (member([barrada, _, 4], Triples);
     member([_, clothesline, 4], Triples)),
    
    % 3. Nikto did not make his sighting on Tuesday
    \+ member([nikto, _, 1], Triples),
    
    % 4. Klatu isn't the one whose object turned out to be a water tower
    \+ member([klatu, watertower, _], Triples),
    
    % Prints out the solution
    tell(gort, GortObj, GortDay),
    tell(nikto, NiktoObj, NiktoDay),
    tell(klatu, KlatuObj, KlatuDay),
    tell(barrada, BarradaObj, BarradaDay).
    
% Earlier day
earlier(EarlierDay, LaterDay) :- EarlierDay < LaterDay.
                                                                                       
% Succeed if all elements of the argument list are bound and different.
% Fail if any elements are unbound or equal to some other element.
all_different([H | T]) :- member(H, T), !, fail.        % (1)
all_different([_ | T]) :- all_different(T).             % (2)
all_different([_]).                                     % (3)

Write out an English sentence with the solution given the person, object and day number
tell(Person, Object, DayNum) :-
    format('~w sighted ~w on ', [Person, Object]),
    ( DayNum =:= 1 -> write("tuesday");
      DayNum =:= 2 -> write("wednesday");
      DayNum =:= 3 -> write("thursday");
                      write("friday")),
    nl.
   