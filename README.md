# Sitecore Referenception Module

## Installation
### Manual Installation
You can clone the repository and build the source code. You need to copy all assemblies listed in the README.md in the _lib_ directory, otherwise you won't be able to build because of missing references. There are some MSBuild targets which copies all needed files into a directory defined in the _build/deploy.txt_ file. Just create the _build/deploy.txt_ file and insert the directory where you want to copy all the files to.