# Taken from https://github.com/devhawk/pygments.wlwriter

from System import IO

def walk(folder):
  for file in IO.Directory.GetFiles(folder):
    yield file
  for folder in IO.Directory.GetDirectories(folder):
    for file in walk(folder): yield file
  
folder = IO.Path.GetDirectoryName(__file__)

pygments_files = list(walk(IO.Path.Combine(folder, 'pygments')))
pygments_dependencies = list(walk(IO.Path.Combine(folder, 'dependencies')))

all_files = pygments_files  + pygments_dependencies

import clr
clr.CompileModules(IO.Path.Combine(folder, "..\..\intermediate\pygments.dll"), *all_files)
