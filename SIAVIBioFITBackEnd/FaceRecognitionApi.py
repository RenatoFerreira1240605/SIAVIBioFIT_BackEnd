import face_recognition
import sys
import json

if len(sys.argv) != 3:
    print(json.dumps({"match": False, "email": None}))
    sys.exit(1)

reference_path = sys.argv[1]
captured_path = sys.argv[2]

try:
    ref_image = face_recognition.load_image_file(reference_path)
    cap_image = face_recognition.load_image_file(captured_path)

    ref_encodings = face_recognition.face_encodings(ref_image)
    cap_encodings = face_recognition.face_encodings(cap_image)

    if len(ref_encodings) == 0 or len(cap_encodings) == 0:
        raise Exception("Face not found in one of the images.")

    match = face_recognition.compare_faces([ref_encodings[0]], cap_encodings[0])[0]

    result = {
        "match": match,
        "email": None  # backend decidirá qual email está associado
    }

    print(json.dumps(result))
except Exception as e:
    result = {
        "match": False,
        "email": None,
        "error": str(e)
    }
    print(json.dumps(result))
