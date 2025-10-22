defmodule AirportKioskSystemServer do
  def startServer do
    {:ok, listen_socket} = :gen_tcp.listen(4001, [:binary, reuseaddr: true])
    
    for _ <- 0..1000, do: spawn(fn -> handleServer(listen_socket) end)
    Process.sleep(:infinity)
  end

  def handleServer(listen_socket) do
    {:ok, socket} = :gen_tcp.accept(listen_socket)

    receive do
      {:tcp, ^socket, data} ->
        :ok = :gen_tcp.send(socket, "Hello World! Your message: #{data}")
        IO.puts(data)
    end

    :ok = :gen_tcp.shutdown(socket, :read_write)
    handleServer(listen_socket)
  end
end

AirportKioskSystemServer.startServer()

