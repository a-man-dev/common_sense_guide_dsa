

var alice = new Vertex("alice");
var bob = new Vertex("bob");
var cynthia = new Vertex("cynthia");

alice.AddAdjacentVertex(bob);
alice.AddAdjacentVertex(cynthia);
bob.AddAdjacentVertex(cynthia);
cynthia.AddAdjacentVertex(bob);

var a = new Vertex("a");
var b = new Vertex("b");
var c = new Vertex("c");
var d = new Vertex("d");
var e = new Vertex("e");
var f =  new Vertex("f");
var g =  new Vertex("g");

a.AddAdjacentVertex(b);
b.AddAdjacentVertex(c);
b.AddAdjacentVertex(f);
a.AddAdjacentVertex(d);
a.AddAdjacentVertex(e);
d.AddAdjacentVertex(g);

DFStraverse(a);

Console.WriteLine("_-_-_");
var dallas = new WeightedGraphVertex("Dallas");
var toronto = new WeightedGraphVertex("Toronto");

dallas.AddAdjacentVertex(toronto, 138);
toronto.AddAdjacentVertex(dallas, 216);

Console.WriteLine("Dijkstras algo section start!");
var atlanta = new City("Atlanta");
var boston = new City("Boston");
var chicago = new City("Chicago");
var denver  = new City("Denver");
var el_paso = new City("El Paso");

atlanta.AddRoute(boston, 100);
atlanta.AddRoute(denver, 160);
boston.AddRoute(chicago, 120);
boston.AddRoute(denver, 180);
chicago.AddRoute(el_paso, 80);
denver.AddRoute(chicago, 40);
denver.AddRoute(el_paso, 140);
el_paso.AddRoute(boston, 100);

Vertex DFS(Vertex vertex, string searchValue, Dictionary<string, bool> visitedVertices = null) {
	visitedVertices ??= new();

	if (vertex.Value == searchValue) {
		return vertex;
	}

	visitedVertices.Add(vertex.Value, true);

	foreach (var v in vertex.AdjacentVertices) {
		if (visitedVertices.ContainsKey(v.Value))
			continue;

		var vertexSearched = DFS(v, searchValue, visitedVertices);
		
		if (vertexSearched != null) 
			return vertexSearched;
	}

	return null;
}

void DFStraverse(Vertex vertex, Dictionary<string, bool> visitedVertices = null) {
	visitedVertices ??= new();

	visitedVertices.Add(vertex.Value, true);

	Console.WriteLine(vertex.Value);

	foreach(var v in vertex.AdjacentVertices) {
		if (visitedVertices.ContainsKey(v.Value))
			continue;
		DFStraverse(v, visitedVertices);
	}
}

class City {
	public string Name { get; set; }
	public Dictionary<City, int> Routes { get; set; }

	public City(string name) {
		Name = name;
		Routes = new();
	}

	public void AddRoute(City city, int price) {
		Routes.Add(city, price);
	}
}

class WeightedGraphVertex {
	public string Value { get; set; }
	public Dictionary<WeightedGraphVertex, int> AdjacentVertices { get; set; }

	public WeightedGraphVertex(string value) {
		Value = value;
		AdjacentVertices = new();
	}

	public void AddAdjacentVertex(WeightedGraphVertex vertex, int weight) {
		AdjacentVertices.Add(vertex, weight);
	}
}

class Vertex {
	public string Value { get; set; }
	public List<Vertex> AdjacentVertices { get; set; }

	public Vertex(string value) {
		Value = value;
		AdjacentVertices = new();
	}

	public void AddAdjacentVertex(Vertex vertex) {
		if (AdjacentVertices.Contains(vertex)) {
			Console.WriteLine($"{Value} is already friend with {vertex.Value}");
			return;
		}

		AdjacentVertices.Add(vertex);
		vertex.AddAdjacentVertex(this);
	}
}


