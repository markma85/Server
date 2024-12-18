#!/bin/bash
apt-get update -y
apt-get install -y wget
wget https://raw.githubusercontent.com/markma85/Setup-Jenkins-Build-Env/main/jenkins-dotnet.bash -O /tmp/jenkins-dotnet.bash
chmod +x /tmp/jenkins-dotnet.bash
/tmp/jenkins-dotnet.bash --ip-public $(curl -s http://metadata.google.internal/computeMetadata/v1/instance/network-interfaces/0/access-configs/0/external-ip -H 'Metadata-Flavor: Google') --docker-host 127.0.0.1 --docker-port 2375 >> /tmp/startup-log.txt 2>&1
echo "Custom bash script executed successfully!" >> /tmp/startup-log.txt