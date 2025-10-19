defmodule AirportKioskSystemServer do
  def start do
    startServer()
  end

  def startServer do
    {:ok, listen_socket} = :gen_tcp.listen(4001, [:binary, reuseaddr: true])
    
    for _ <- 0..100, do: spawn(fn -> handleServer(listen_socket) end)
    Process.sleep(:infinity)
  end

  def handleServer(listen_socket) do
    {:ok, socket} = :gen_tcp.accept(listen_socket)
    :ok = :gen_tcp.send(socket, d <> "Hello World!")
    :ok = :gen_tcp.shutdown(socket, :read_write)
    handleServer(listen_socket)
end
