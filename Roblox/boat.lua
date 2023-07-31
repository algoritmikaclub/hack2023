local Seat = script.Parent.VehicleSeat
local params = RaycastParams.new()
params.FilterDescendantsInstances = {workspace.Terrain}
params.FilterType = Enum.RaycastFilterType.Whitelist

Seat.Changed:Connect(function()
	script.AngularVelocity.AngularVelocity = Vector3.new(0,-1 * Seat.Steer,0)
	script.LinearVelocity.LineVelocity = 50 * Seat.Throttle
end)
	while task.wait() do
		local sPos = script.Parent.VehicleSeat.Position + Vector3.new(0,5,0) -- The * needs to be changed to +.
		local ePos = script.Parent.VehicleSeat.Position - Vector3.new(0,15,0) -- The * needs to be changed to -.
		local ray = workspace:Raycast(sPos,ePos - sPos,params) -- The . in workspace.Raycast needs to be switched to :.

		if ray and ray.Material == Enum.Material.Water then -- The m in ray.material needs to be capitalized.
			script.AngularVelocity.Enabled = true
			script.LinearVelocity.Enabled = true
		else
			script.AngularVelocity.Enabled = false
			script.LinearVelocity.Enabled = false
		end
	end
