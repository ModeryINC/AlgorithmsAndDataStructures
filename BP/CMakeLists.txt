cmake_minimum_required(VERSION 3.10)
project(CelticGame)

set(CMAKE_CXX_STANDARD 17)
set(CMAKE_CXX_STANDARD_REQUIRED ON)
set(CMAKE_CXX_COMPILER x86_64-w64-mingw32-g++)
set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -static -static-libgcc -static-libstdc++")
set(CMAKE_EXE_LINKER_FLAGS "-static")

include_directories(
    ${PROJECT_SOURCE_DIR}/Characters
    ${PROJECT_SOURCE_DIR}/Utilities
    ${PROJECT_SOURCE_DIR}/WorldGenerator
)

add_executable(CelticGame
    main.cpp

    Characters/Character.cpp
    Characters/Enemy.cpp
    Characters/Player.cpp

    Utilities/functions.cpp
    Utilities/RandomGenerator.cpp
    Utilities/struct.cpp

    WorldGenerator/Graph.cpp
    WorldGenerator/Map.cpp
)

target_link_libraries(CelticGame pthread)