defmodule AirportKioskSystemServerTest do
  use ExUnit.Case
  doctest AirportKioskSystemServer

  test "greets the world" do
    assert AirportKioskSystemServer.hello() == :world
  end
end
