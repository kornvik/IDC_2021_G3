# IDC_2021_G3
This is the code and design of my team in International Design Contest Robocon 2021 which is the winner of the competition. The competition is held online. Participants have to design the robot by CAD and import to Unity to program to robot.

The goal of the competition is to put the ball in the nest or the box on one side of the field. 
We choose to go for winning condition of the competition where we have to put the balls in each of the nests (buckets on the slope) and 
place the sky ball which is the ball in the middle inside the transparent box.

According to the rules, we can preload the balls up to 3 balls.
Thus, our strategy is to collect the sky ball as fast as possible.
The rest is the history! 

For the design part, we embrace the idea of simple but efficient design.

<img src="https://user-images.githubusercontent.com/40062331/130056163-593d923d-d950-42c1-8bdd-abf0d69b3f8b.png" alt="drawing" style="height:200px;"/>
<img src="https://user-images.githubusercontent.com/40062331/130056210-0dc0e46b-c2c3-47dc-a663-735b3f79caff.png" alt="drawing" style="height:200px;"/>


We can selectively drop the ball by spinning the red cover on the bottom of the robot(flying toilet).

For the software part, we implement simple pid control to partially automate the robot.
To control robot
w,a,s,d to move robot on ground plane. 
p,l to move up and down.
o,i for automove from starting point (i is faster version of o).
r,t to rotate the cover.
k to cancle the autopilot (turn off after getting the ball in the middel).
1,2,3,4,5 for changing camera view. (recommend only 1 and 2).

Pictures during the competition.
Collecting the sky ball
![Screenshot 2021-08-07 221303 (2)](https://user-images.githubusercontent.com/40062331/130056924-f1187eb0-083e-4580-84f6-6534c39bc261.jpg)

Dropping the preloaded balls
![Screenshot 2021-08-07 221231 (2)](https://user-images.githubusercontent.com/40062331/130056797-58e72635-0f37-4bb3-8acc-a83dc2867c37.jpg)

Placing the sky ball in the box
![sdfgh (2)](https://user-images.githubusercontent.com/40062331/130057139-32cc0614-aa5b-4a9b-91d7-2aed3e87147b.jpg)

Our team : 
  1. Tanpipat Kornvik (Leader, Software Lead)
  2. Chung Gene
  3. K. S. Sankardas (Mechanics Lead) 
  4. Worrasak Yonglan
  5. Yao Boxian
  6. Caio Felipe dos Santos Oliverira
