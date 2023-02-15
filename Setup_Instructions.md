1. Install XCode.

2. Install Unity Hub.

3. Install Unity Editor (intel version)
 - Go to the “Installs”, then install the latest version that has a “intel” tag on it. PLEASE make sure it is the “intel” version and not “apple silicon” as apple silicon version will not be supported in all our laptops. 
 - Add “IOS Build support” module when prompted.
   - If not prompted, go to “Installs” and select the Editor’s settings. Then “Add modules” > IOS Build Support.

4. Now open your terminal and navigate to the directory where you want the project. Run “gh repo clone COSC-4P02-Team-REX/CLIO”
 - If you're not connected to github or do not have gh installed then run "brew install gh" and then "gh auth login". 

5. Go back to Unity Hub and select “Projects”. Hit “Open” and select the folder where you put (cloned) project files. This will take a minute.

6. Once the editor is open, go to “File” > “Build Settings”. Select “IOS” if not already selected and hit “Switch Platform”.

7. Go to “File” > “Build and Run”. When prompted to select a folder to build, Create a new folder in the main project folder and name it “Build” and “choose” that folder. PLEASE make sure you name the new folder “Build” and choose that folder to build the app. It is very important to name the folder EXACTLY “Build”

8. That will open XCode. In XCode, you’ll get an error for provisioning profile. Go to Project Manager (Folder Icon on top left) on the left sidebar and select “Unity-iPhone”. Select “Signing and Capabilities” and under that, check “Automatically manage signing”.

9. Select “Team” dropdown and hit “Add an Account”. Sign in with your apple ID. In the same window, hit “Manage Certificates” and click on the “+” sign on the bottom left corner and select “Apple Development”. Hit Done and then click “Download Manual Profiles”. You can close that window now.

10. Now Click “Team” and select your name. Write some variation of App’s name in “Bundle Identifier” as everyone has to have a unique bundle identifier name. 

11. Connect an iPhone/iPad with a USB cable and go to “Project Manager” > “Unity-iPhone” and in the window, in “General” select the device you connected. 

12. If the device is not showing up, go to the devices setting and under privacy and security, turn on developer mode. The device will restart. 

13. Once it restarts, go to Settings > General > Profile and Device Management. Click on your apple ID and hit “Trust your@email.com”
 - If you don’t see Profile and Device Management in there, It’ll probably be under VPN. 

14. Now hit the run button (top left corner play button) and the app will install on the connected device.

15. If any issues, ask on slack, someone will know and can help fix it.
