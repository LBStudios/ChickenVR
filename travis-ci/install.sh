#!/bin/bash

# Install script for Chicken VR with Travis-CI

echo "Downloading from https://download.unity3d.com/download_unity/de9eb5ca33c5/MacEditorInstaller/Unity-2017.4.7f1.pkg"
curl -o Unity.pkg https://download.unity3d.com/download_unity/de9eb5ca33c5/MacEditorInstaller/Unity-2017.4.7f1.pkg

echo "Installing Unity.pkg"
sudo installer -dumplog -package Unity.pkg -target /